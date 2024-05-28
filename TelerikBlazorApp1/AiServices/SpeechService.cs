using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.CognitiveServices.Speech;
using Microsoft.JSInterop;
namespace TelerikBlazorApp1.Services
{
    public class SpeechService
    {
        private readonly string speechApiKey;
        private readonly string serviceRegion;

        public SpeechService(IConfiguration config)
        {
            speechApiKey = config["SpeechApiKey"]
                ?? throw new MissingConfigurationException();
            serviceRegion = config["ServiceRegion"]
                ?? throw new MissingConfigurationException();
        }
        public async Task<byte[]> GetSpeech(string text)
        {
            var speechConfig = SpeechConfig.FromSubscription(speechApiKey, serviceRegion);
            speechConfig.SpeechSynthesisLanguage = "en-US"; // Specify the language of the voice
            speechConfig.SpeechSynthesisVoiceName = "en-US-DavisNeural"; // Specify the voice name

            using var synthesizer = new SpeechSynthesizer(speechConfig, null);
            var result = await synthesizer.SpeakTextAsync(text);

            if (result.Reason == ResultReason.Canceled)
            {
                var cancellation = SpeechSynthesisCancellationDetails.FromResult(result);
                Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");
                Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                Console.WriteLine($"CANCELED: ErrorDetails={cancellation.ErrorDetails}");
                Console.WriteLine($"CANCELED: Did you update the subscription info?");
                return [];
            }

            return result.AudioData;
        }
    }
}
