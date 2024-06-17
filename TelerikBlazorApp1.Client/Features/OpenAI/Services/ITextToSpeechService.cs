namespace TelerikBlazorApp1.Client.Features.OpenAI.Services;
public interface ITextToSpeechService
{
    Task<string> RequestTextToSpeak(string textToSpeak);
}
