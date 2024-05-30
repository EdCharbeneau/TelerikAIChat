using Microsoft.AspNetCore.Mvc;
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

            app.MapPost("/upload", async ([FromForm] IFormFileCollection myFiles) =>
            {
                // Define the path to the wwwroot directory
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", myFiles[0].FileName);

                // Save the file to the wwwroot directory
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await myFiles[0].CopyToAsync(stream);
                }

                return Results.Ok(new { filePath }); // Return the file path or other relevant response
            }).Accepts<IFormFile>("multipart/form-data").DisableAntiforgery(); ;

            app.MapPost($"/theme/color", async (
                HttpContext ctx,
                [FromBody] string imageUrl,
                [FromServices] ComputerVision vision) =>
                 await vision.GetColorThemeReferenceFromImageUrl(new UriBuilder() {  Host = ctx.Request.Host.Host.ToString(), Scheme = ctx.Request.Scheme, Port = ctx.Request.Host.Port ?? 0, Path = imageUrl }.Uri.ToString())
                 );
        }
    }
}
