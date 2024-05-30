using System.Net.Http.Json;
using TelerikBlazorApp1.Client;
using TelerikBlazorApp1.Client.Services;

public record AiConversation(string userMessage, string assistantMessage);
public class OpenAiHttpService(HttpClient httpClient) : IOpenAiService
{
    public async Task<string> MakeAiRequest(string prompt)
    {
        var result = await httpClient.PostAsJsonAsync<string>("/openai", prompt);
        var chatResult = await result.Content.ReadAsStringAsync();
        return chatResult;
    }

    public async Task<string> MakeAiRequest(AiConversation chat)
    {
        var result = await httpClient.PostAsJsonAsync<AiConversation>("/openai", chat);
        var chatResult = await result.Content.ReadAsStringAsync();
        return chatResult;
    }


}

public class OpenAiServiceFake : IOpenAiService
{
    public async Task<string> MakeAiRequest(string prompt)
    {
        await Task.Delay(2000);

        return await Task.FromResult("Hello, I am Hal.");
    }

    public Task<string> MakeAiRequest(AiConversation chat) => MakeAiRequest("");
}