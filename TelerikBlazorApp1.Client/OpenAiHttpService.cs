using System.Net.Http.Json;
using TelerikBlazorApp1;
using TelerikBlazorApp1.Client;

public class OpenAiHttpService : IOpenAiService
{
    private readonly HttpClient httpClient;

    public OpenAiHttpService(HttpClient httpClient) => this.httpClient = httpClient;
    public async Task<string> MakeAiRequest(string prompt)
    {
        var result = await httpClient.PostAsJsonAsync<string>("/openai", prompt);
        var chat = await result.Content.ReadAsStringAsync();
        return chat;
    }


}

public class OpenAiServiceFake : IOpenAiService
{
    public async Task<string> MakeAiRequest(string prompt)
    {
        await Task.Delay(2000);

        return await Task.FromResult("Hello, I am Hal.");
    }
}