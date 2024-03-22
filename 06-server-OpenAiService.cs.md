using Azure.AI.OpenAI;
using Azure;
using TelerikBlazorAppDemo.Client.Services;

namespace TelerikBlazorAppDemo.Services
{
    public class OpenAiService(IConfiguration config) : IOpenAiService
    {
        public async Task<string> MakeAiRequest(string prompt)
        {
            // OpenAiKey is supplied through User Secrets
            OpenAIClient client = new OpenAIClient(config["OpenAiKey"], new OpenAIClientOptions());
            var chatCompletionsOptions = new ChatCompletionsOptions()
            {
                DeploymentName = "gpt-3.5-turbo", // Use DeploymentName for "model" with non-Azure clients
                Messages =
                {
                    new ChatRequestUserMessage(prompt),
                }
            };
            Response<ChatCompletions> response = await client.GetChatCompletionsAsync(chatCompletionsOptions);
            ChatResponseMessage responseMessage = response.Value.Choices[0].Message;
            return responseMessage.Content;
        }
    }
}