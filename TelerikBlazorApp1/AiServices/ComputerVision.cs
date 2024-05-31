using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using TelerikBlazorApp1.Services;

namespace TelerikBlazorApp1.AiServices
{
    public class ComputerVision
    {
        private readonly string key;
        private readonly string endpoint;
        public ComputerVision(IConfiguration config)
        {
            key = config["VisionApiKey"] ?? throw new MissingConfigurationException();
            endpoint = config["VisionEndpoint"] ?? throw new MissingConfigurationException();
        }

        public async Task<string> GetColorThemeReferenceFromImageUrl(Stream image)
        {
            ComputerVisionClient client =
  new ComputerVisionClient(
      new ApiKeyServiceClientCredentials(key))
  { Endpoint = endpoint };

            string temp = "https://moderatorsampleimages.blob.core.windows.net/samples/sample16.png";

            List<VisualFeatureTypes?> features = new List<VisualFeatureTypes?>()
                            {
                                VisualFeatureTypes.Color
                            };
            try
            {

                ImageAnalysis results = await client.AnalyzeImageInStreamAsync(image, visualFeatures: features);
                return results.Color.AccentColor;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

    }
}

