using Blazored.LocalStorage;

namespace TelerikBlazorApp1.Client.Features.Theme.Services
{
    public static class ThemeServices
    {
        public static IServiceCollection AddThemeServices(this IServiceCollection services)
        {
            services.AddBlazoredLocalStorageAsSingleton();
            services.AddScoped<ThemeState>();
            services.AddScoped<CardState>();
            return services;
        }
    }
}
