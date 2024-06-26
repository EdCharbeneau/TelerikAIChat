﻿namespace TelerikBlazorApp1.Client.Features.OpenAI;
public partial class Assistant
{
    bool isBusy = false;
    bool isPlaying = false;
    string? audio;
    public string prompt = "";
    public TelerikAIPrompt? AIPromptRef { get; set; }
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await SpeechRecognition.InitializeModuleAsync();
        }
    }
    public async Task HandlePromptRequest(AIPromptPromptRequestEventArgs args)
    {
        isBusy = true;
        if (string.IsNullOrWhiteSpace(args.Prompt))
        {
            args.Prompt = "I need a recipe for unicorn pie.";
        }

        string result = await service.MakeAiRequest(args.Prompt);
        AIPromptRef?.AddOutput(result, "Prompt:", prompt, prompt, null, true);
        state.Add(new(result, args.Prompt, DateTime.UtcNow));
        isBusy = false;
        await OnSpeak(result);
    }

    public void OnRecord() =>
        SpeechRecognition.RecognizeSpeech("en",
        onRecognized: OnRecognized,
        onError: (err) => throw new Exception(err.Message),
        onStarted: OnStarted,
        onEnded: OnEnded);

    public async void OnRecognized(string recognizedText)
    {
        prompt = recognizedText;
        await HandlePromptRequest(new() { Prompt = prompt });
        SpeechRecognition.CancelSpeechRecognition(true);
    }
    public void OnEnded()
    {
        isBusy = false;
        StateHasChanged();
    }
    public void OnStarted()
    {
        isBusy = true;
        StateHasChanged();
    }
    public async Task OnSpeak(string textToSpeak)
    {
        audio = await TextToSpeech.RequestTextToSpeak(textToSpeak);
        isPlaying = true;
    }

}
