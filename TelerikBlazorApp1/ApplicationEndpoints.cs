using Microsoft.AspNetCore.Mvc;
using TelerikBlazorApp1.Client.Services;
using TelerikBlazorApp1.Services;

namespace TelerikBlazorApp1
{
    public static class ApplicationEndpoints
    {
        public static void MapApplicationEndpoints(this WebApplication app)
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

        }
    }
}
