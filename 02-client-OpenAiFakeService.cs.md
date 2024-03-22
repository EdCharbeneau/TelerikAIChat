namespace TelerikBlazorAppDemo.Client.Services
{
    public class OpenAiServiceFake // create an interface here
    {
        public async Task<string> MakeAiRequest(string prompt)
        {
            await Task.Delay(2000);

            return await Task.FromResult("Hello, I am Hal.");
        }

        // Add converstations later
        //public Task<string> MakeAiRequest(AiConversation chat) => MakeAiRequest("");
    }
}

// Program.cs
// builder.Services.AddScoped<IOpenAiService, OpenAiServiceFake>();
