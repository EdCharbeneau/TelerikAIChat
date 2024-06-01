using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TelerikBlazorApp1.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IOpenAiService, OpenAiHttpService>();
builder.Services.AddScoped<ConversationState>();
builder.Services.AddScoped<ITextToSpeechService, TextToSpeechService>();
builder.Services.AddSpeechRecognitionServices();

builder.Services.AddTelerikBlazor();

await builder.Build().RunAsync();
