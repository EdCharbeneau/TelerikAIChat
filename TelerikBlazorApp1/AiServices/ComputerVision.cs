﻿using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using TelerikBlazorApp1.Services;
using TelerikBlazorApp1.Client.Pages.Theme;

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

        public async Task<ImageAnalysis> GetColorThemeReferenceFromImageUrl(byte[]? imageData)
        {
            if (imageData == null || imageData.Length == 0)
            {
                throw new ArgumentNullException(nameof(imageData), "The image data is null or empty, it cannot be used for Azure request.");
            }

            var client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(key)) { Endpoint = endpoint };

            var features = new List<VisualFeatureTypes?> { 
                VisualFeatureTypes.Color,
                VisualFeatureTypes.Description
            };

            try
            {
                var results = await client.AnalyzeImageInStreamAsync(
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
}

