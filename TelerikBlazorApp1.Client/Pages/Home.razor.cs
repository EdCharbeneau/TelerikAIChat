using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Telerik.Blazor.Components;
using TelerikBlazorApp1.Client.Services;

namespace TelerikBlazorApp1.Client.Pages
{
    public partial class Home : ComponentBase
    {
        bool isRecording = false;
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
            string result = await service.MakeAiRequest(args.Prompt);
            AIPromptRef?.AddOutput(result, "Prompt:", prompt, prompt, null, true);
            state.Add(new(result, args.Prompt, DateTime.UtcNow));
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
            isRecording = false;
            StateHasChanged();
        }
        public void OnStarted()
        {
            isRecording = true;
            StateHasChanged();
        }
        public async Task OnSpeak(string textToSpeak)
        {
            audio = await TextToSpeech.RequestTextToSpeak(textToSpeak);
            isPlaying = true;
        }

    }
}
