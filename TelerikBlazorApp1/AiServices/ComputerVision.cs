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

        public async Task<string> GetColorThemeReferenceFromImageUrl(Stream image)
        {
            ImageAnalysis imageAnalysis = await AnalyzeImageUrl(Authenticate(), image);
            return imageAnalysis.Color.AccentColor;
        }


        private ComputerVisionClient Authenticate()
        {
            ComputerVisionClient client =
              new ComputerVisionClient(new ApiKeyServiceClientCredentials(key))
              { Endpoint = endpoint };
            return client;
        }

        private async Task<ImageAnalysis> AnalyzeImageUrl(ComputerVisionClient client, Stream image)
        {
            // Creating a list that defines the features to be extracted from the image. 
            List<VisualFeatureTypes?> features = new List<VisualFeatureTypes?>()
                            {
                                VisualFeatureTypes.Tags
                            };
            try
            {

            ImageAnalysis results = await client.AnalyzeImageInStreamAsync(image, visualFeatures: features);
                return results;
            }
            catch (Exception ex)
            {
                throw;
            }

            // Analyze the URL image 

        }

    }
}

