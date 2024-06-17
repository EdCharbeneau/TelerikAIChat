namespace TelerikBlazorApp1.Client.Features.OpenAI.Services;

public static class OpenAIServices
{
    public static IServiceCollection AddOpenAiServices(this IServiceCollection services)
    {
        services.AddScoped<IOpenAiService, OpenAiHttpService>();
        services.AddScoped<ConversationState>();
        services.AddScoped<ITextToSpeechService, TextToSpeechService>();
        services.AddSpeechRecognitionServices();
        return services;
    }
}

