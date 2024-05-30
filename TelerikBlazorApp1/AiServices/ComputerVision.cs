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
            key = config["VisionApiKey"]
    ?? throw new MissingConfigurationException();
            endpoint = config["VisionEndpoint"]
                ?? throw new MissingConfigurationException();
        }

        public async Task<string> GetColorThemeReferenceFromImageUrl(string imageUrl)
        {
            ImageAnalysis imageAnalysis = await AnalyzeImageUrl(Authenticate(), imageUrl);
            return imageAnalysis.Color.AccentColor;
        }


        private ComputerVisionClient Authenticate()
        {
            ComputerVisionClient client =
              new ComputerVisionClient(new ApiKeyServiceClientCredentials(key))
              { Endpoint = endpoint };
            return client;
        }

        private async Task<ImageAnalysis> AnalyzeImageUrl(ComputerVisionClient client, string imageUrl)
        {
            // Creating a list that defines the features to be extracted from the image. 
            List<VisualFeatureTypes?> features = new List<VisualFeatureTypes?>()
                            {
                                VisualFeatureTypes.Color
                            };
            ImageAnalysis results = await client.AnalyzeImageAsync(imageUrl, visualFeatures: features);

            // Analyze the URL image 
            return results;
        }

    }
}

