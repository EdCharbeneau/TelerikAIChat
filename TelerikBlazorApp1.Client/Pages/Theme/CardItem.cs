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
}
