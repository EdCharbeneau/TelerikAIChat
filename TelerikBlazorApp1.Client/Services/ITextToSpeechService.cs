
namespace TelerikBlazorApp1.Client.Services;
public interface ITextToSpeechService
{
    Task<string> RequestTextToSpeak(string textToSpeak);
}
