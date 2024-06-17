using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System.IO;
using TelerikBlazorApp1.Client.Pages.Theme;
using TelerikBlazorApp1.Client.Services;
using TelerikBlazorApp1.Services;

namespace TelerikBlazorApp1.AiServices
{
    public static class AiEndpoints
    {
        public static void MapAiEndpoints(this WebApplication app)
        {
            app.MapPost($"/openai", async (
                [FromBody] string prompt,
                [FromServices] IOpenAiService openAi) =>
                 await openAi.MakeAiRequest(prompt)
                 )
            .WithName("OpenAI")
            .WithOpenApi();

            app.MapPost($"/openai-chat", async (
                [FromBody] AiConversation chat,
                [FromServices] IOpenAiService openAi) =>
                 await openAi.MakeAiRequest(chat)
                 )
            .WithName("OpenAIChat")
            .WithOpenApi();

            app.MapPost($"/speech/audio", async (
                [FromBody] string text,
                [FromServices] SpeechService speechService
                ) =>
            {
                byte[] audio = await speechService.GetSpeech(text);

                // Replace 'audio/mpeg' with the correct MIME type for your audio file
                var mimeType = "audio/mpeg";
                return Results.File(audio, contentType: mimeType, fileDownloadName: "audiofile.mp3");
            });

            app.MapPost("/upload", async ([FromForm] IFormFileCollection myFiles,
                [FromServices] ComputerVision vision) =>
            {
                // Holds pixel data from file.
                byte[]? imgBytes = null;

                // Fully flush out the uploaded file Stream into a MemoryStream then copy into the byte[]
                using var ms = new MemoryStream();
                await myFiles[0].CopyToAsync(ms);
                imgBytes = ms.ToArray();

                // Define the path to the wwwroot directory
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", myFiles[0].FileName);

                // Save the file to the wwwroot directory
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await myFiles[0].CopyToAsync(stream);
                }

                // Use the image data to Azure functionality
                ImageAnalysis result = await vision.GetColorThemeReferenceFromImageUrl(imgBytes);

                return result;

            }).Accepts<IFormFile>("multipart/form-data").DisableAntiforgery();

        }
    }
}
