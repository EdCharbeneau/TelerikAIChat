
namespace TelerikBlazorApp1.Client.Services
{
    public interface IComputerVisionService
    {
        Task<string> RequestThemeFromImageUrl(string imageUrl);
    }
}