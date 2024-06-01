using System.ComponentModel.DataAnnotations;

namespace TelerikBlazorApp1.Client.Pages.Theme
{
    public class CardItem
    {

        public string Title { get; set; } = "Untitled";

        public string SubTitle { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        public bool IsLiked { get; set; }
        
        public int Likes { get; set; }

        public bool IsLoading { get; set; }

        public string AccentColor { get; set; } = "#003366";
    }
}
