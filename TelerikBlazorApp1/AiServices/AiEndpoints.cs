using Microsoft.AspNetCore.Mvc;
using System.IO;
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
                using (var stream = new MemoryStream())
                {
                    await myFiles[0].CopyToAsync(stream);
                    var result = await vision.GetColorThemeReferenceFromImageUrl(stream);
                    return Results.Ok(new { result }); 
                }

            }).Accepts<IFormFile>("multipart/form-data").DisableAntiforgery(); ;

        }
    }
}
