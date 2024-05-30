using System.Net.Http;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace TelerikBlazorApp1.Client.Services
{

    public class ComputerVisionService(HttpClient httpClient) : IComputerVisionService
    {
        public async Task<string> RequestThemeFromImageUrl(string imageUrl)
        {
            var result = await httpClient.PostAsJsonAsync<string>("/theme/color", imageUrl);
            var colorResult = await result.Content.ReadAsStringAsync();
            return colorResult;
        }

    }

}
