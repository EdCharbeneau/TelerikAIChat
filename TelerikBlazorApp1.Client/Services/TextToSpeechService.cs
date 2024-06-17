using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace TelerikBlazorApp1.Client.Services;
public class TextToSpeechService(HttpClient http) : ITextToSpeechService
{
    public async Task<string> RequestTextToSpeak(string textToSpeak)
    {
        HttpResponseMessage response = await http.PostAsJsonAsync("/speech/audio", textToSpeak);
        response.EnsureSuccessStatusCode();
        byte[] byteArray = await response.Content.ReadAsByteArrayAsync();

        // Convert the byte array to a base64 string
        string base64String = Convert.ToBase64String(byteArray);
        string audio = $"data:audio/mp3;base64,{base64String}";
        return audio;
    }

}
