@using TelerikBlazorAppDemo.Client.Services
@inject IOpenAiService service

//@code...
    public async Task HandlePromptRequest(AIPromptPromptRequestEventArgs args)
    {
        string result = await service.MakeAiRequest(args.Prompt);
        args.Output = result;
    }