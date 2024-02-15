using OpenAI_API.Chat;
using OpenAI_API.Models;
using TelerikBlazorApp1.Client;

namespace TelerikBlazorApp1
{
    public class OpenAiService(IConfiguration config) : IOpenAiService
    {
        public async Task<string> MakeAiRequest(string prompt)
        {
            var api = new OpenAI_API.OpenAIAPI(config["OpenAiKey"]);
            var result = await api.Chat.CreateChatCompletionAsync(new ChatRequest()
            {
                Model = Model.ChatGPTTurbo,
                Temperature = 0.5,
                MaxTokens = 500,
                Messages = new ChatMessage[] {
            new ChatMessage(ChatMessageRole.User, prompt)
        }
            });
            return result.ToString();
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
}
