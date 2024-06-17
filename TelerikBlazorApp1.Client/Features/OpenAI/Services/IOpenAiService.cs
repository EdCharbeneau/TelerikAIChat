namespace TelerikBlazorApp1.Client.Features.OpenAI.Services;
public interface IOpenAiService
{
    Task<string> MakeAiRequest(string prompt);
    Task<string> MakeAiRequest(AiConversation chat);
}
