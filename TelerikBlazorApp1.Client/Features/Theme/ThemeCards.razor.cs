namespace TelerikBlazorApp1.Client.Features.Theme;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System.Text.Json;
public partial class ThemeCards
{
    private bool isLoading;

    protected override Task OnInitializedAsync() => CardState.InitializeCardState();
    
    public void OnUpload() => isLoading = true;
    private void OnError() => isLoading = false;

    private Task ClearData() => CardState.ClearCardState();

    private void OnSetAsTheme(CardItem item) => ThemeState.SetThemeColor(item.AccentColor);

    private async Task OnLiked(CardItem item)
    {
        item.IsLiked = true;
        item.Likes++;
        await CardState.CardStateHasChanged();
    }

    private async Task OnDisliked(CardItem item)
    {
        item.IsLiked = false;
        item.Likes--;
        await CardState.CardStateHasChanged();
    }

    private async Task OnUploadSuccess(UploadSuccessEventArgs args)
    {
        if (TryGetImageAnalysisFromJson(args.Request.ResponseText, out ImageAnalysis? analysis) && analysis is not null)
        {
            // Create a card from the analysis and add it to the data set
            CardItem newCardItem = analysis.MapToCardItem();
            newCardItem.ImageUrl = args.Files[0].Name;
            
            // persist cards in local storage
            await CardState.Add(newCardItem);

            
        }
        else
        {
            // Handle Error
        }

        isLoading = false;
    }

    private bool TryGetImageAnalysisFromJson(string json, out ImageAnalysis? imageAnalysis)
    {
        ArgumentException.ThrowIfNullOrEmpty(json);

        try
        {
            imageAnalysis = JsonSerializer.Deserialize<ImageAnalysis>(json,
                new JsonSerializerOptions(JsonSerializerDefaults.Web))
                    ?? throw new NullReferenceException("Serialization resulted in a null value");

            return true;
        }
        catch (Exception)
        {
            imageAnalysis = null;
            return false;
        }
    }
}
