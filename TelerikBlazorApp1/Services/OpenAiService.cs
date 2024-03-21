using Azure;
using Azure.AI.OpenAI;

using TelerikBlazorApp1.Client;
using TelerikBlazorApp1.Client.Services;

namespace TelerikBlazorApp1.Services
{
    public class OpenAiService(IConfiguration config) : IOpenAiService
    {
        public async Task<string> MakeAiRequest(string prompt)
        {
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

        public async Task<string> MakeAiRequest(AiConversation chat)
        {
            OpenAIClient client = new OpenAIClient(config["OpenAiKey"], new OpenAIClientOptions());
            var chatCompletionsOptions = new ChatCompletionsOptions()
            {
                DeploymentName = "gpt-3.5-turbo", // Use DeploymentName for "model" with non-Azure clients
                Messages =
                {
                    new ChatRequestAssistantMessage(chat.userMessage),
                    new ChatRequestUserMessage(chat.assistantMessage),
                }
            };
            Response<ChatCompletions> response = await client.GetChatCompletionsAsync(chatCompletionsOptions);
            ChatResponseMessage responseMessage = response.Value.Choices[0].Message;
            return responseMessage.Content;
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
}
