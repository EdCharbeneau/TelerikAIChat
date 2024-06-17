using TelerikBlazorApp1.Client;

namespace TelerikBlazorApp1.Client.Services;
public interface IOpenAiService
{
    Task<string> MakeAiRequest(string prompt);
    Task<string> MakeAiRequest(AiConversation chat);
}
