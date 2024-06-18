using TelerikBlazorApp1.Client.Features.OpenAI.Services;
using TelerikBlazorApp1.Services;

namespace TelerikBlazorApp1.AiServices;

public static class AIServices
{
    public static void AddAiServices(this IServiceCollection services)
    {
        services.AddScoped<IOpenAiService, OpenAiService>();
        services.AddScoped<ConversationState>();
        services.AddScoped<SpeechService>();
        services.AddScoped<ComputerVision>();
    }
}

