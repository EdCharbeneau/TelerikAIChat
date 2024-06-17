using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System.ComponentModel.DataAnnotations;

namespace TelerikBlazorApp1.Client.Pages.Theme
{
    public class CardItem
    {

        public string Title { get; set; } = "Untitled";

        public string? ImageUrl { get; set; }

        public bool IsLiked { get; set; }
        
        public int Likes { get; set; }

        public string AccentColor { get; set; } = "#003366";

        public string[] Description { get; set; } = [];

    }

    public static class CardHelpers
    {
        // Data is received all lower case.
        private static string CapitalizeFirstLetter(this string text) => text.ToUpper()[0] + text[1..];

        public static CardItem MapToCardItem(this ImageAnalysis imageAnalysis) =>
            new()
            {
                //CSS Hex Color format #000000
                AccentColor = $"#{imageAnalysis.Color.AccentColor}",
                Title = imageAnalysis.Description.Captions[0].Text.CapitalizeFirstLetter() + '.',
                Description = imageAnalysis.Description.Tags.ToArray()
            };
    }
}
