using System.Net.Http.Json;

namespace TelerikBlazorAppDemo.Client.Services
{
    public class OpenAiHttpService : IOpenAiService
    {
        private readonly HttpClient httpClient;

        public OpenAiHttpService(HttpClient httpClient) => this.httpClient = httpClient;
        public async Task<string> MakeAiRequest(string prompt)
        {
            var result = await httpClient.PostAsJsonAsync<string>("/openai", prompt);
            var chatResult = await result.Content.ReadAsStringAsync();
            return chatResult;
        }
    }
}

//Program.cs
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//builder.Services.AddScoped<IOpenAiService, OpenAiHttpService>();
