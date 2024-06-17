using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TelerikBlazorApp1.Client.Features.OpenAI.Services;
using TelerikBlazorApp1.Client.Features.Theme.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddOpenAiServices();
builder.Services.AddThemeServices();

builder.Services.AddTelerikBlazor();

await builder.Build().RunAsync();
