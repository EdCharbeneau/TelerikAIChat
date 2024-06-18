using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using TelerikBlazorApp1.Services;

namespace TelerikBlazorApp1.AiServices;

    public class ComputerVision
    {
        private readonly string key;
        private readonly string endpoint;

        public ComputerVision(IConfiguration config)
        {
            key = config["VisionApiKey"] ?? throw new MissingConfigurationException();
            endpoint = config["VisionEndpoint"] ?? throw new MissingConfigurationException();
        }

        public async Task<ImageAnalysis> GetColorThemeReferenceFromImageUrl(byte[]? imageData)
        {
            ArgumentNullException.ThrowIfNull(imageData, nameof(imageData));

            ComputerVisionClient client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(key)) { Endpoint = endpoint };

            List<VisualFeatureTypes?> features = new List<VisualFeatureTypes?> { 
                VisualFeatureTypes.Color,
                VisualFeatureTypes.Description
            };

            try
            {
                ImageAnalysis results = await client.AnalyzeImageInStreamAsync(
                    image: new MemoryStream(imageData),
                    visualFeatures: features);

                return results;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

    }