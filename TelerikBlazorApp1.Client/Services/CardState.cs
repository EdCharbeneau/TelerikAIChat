using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System.Text.Json;
using TelerikBlazorApp1.Client.Pages.Theme;

namespace TelerikBlazorApp1.Client.Services;

public class CardState(Blazored.LocalStorage.ILocalStorageService localStorage)
{
    public List<CardItem> Data { get; set; } = [];

    public async Task InitializeCardState() =>
        Data = await localStorage.GetItemAsync<List<CardItem>>(nameof(CardState)) ?? [];

    public async Task Add(CardItem cardItem)
    {
        Data.Add(cardItem);
        await CardStateHasChanged();
    }

    public async Task CardStateHasChanged() => await localStorage.SetItemAsync(nameof(CardState), Data);
    public async Task ClearCardState() {
        Data = [];
        await CardStateHasChanged();
    }
}