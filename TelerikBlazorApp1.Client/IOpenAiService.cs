using TelerikBlazorApp1.Client;

namespace TelerikBlazorApp1
{
    public interface IOpenAiService
    {
        Task<string> MakeAiRequest(string prompt);
    }
}
