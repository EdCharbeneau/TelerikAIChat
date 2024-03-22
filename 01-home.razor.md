@page "/"

<div>
    <TelerikAIPrompt @ref="@AIPromptRef"
                     @bind-Prompt="@Prompt"
                     OnPromptRequest="@HandlePromptRequest"
                     Width="500px">
    </TelerikAIPrompt>
</div>

@code {
    public string Prompt { get; set; } = "";
    public TelerikAIPrompt? AIPromptRef { get; set; }

    protected override void OnInitialized()
    {
        SetPromptSuggestion();
        base.OnInitialized();
    }


    public void SetPromptSuggestion()
    {
        int index = new Random().Next(PromptSuggestions.Count);
        Prompt = PromptSuggestions[index];
    }

    public List<string> PromptSuggestions { get; set; } = new List<string>()
    {
        "Act as a marketing specialist and content writer and write a compelling [type of text] that speaks directly to my [ideal customer persona] and encourages them to take [desired action] on my [website/product].",
        "I'm looking for a [type of text] that will convince [ideal customer persona] to sign up for my [program/subscription] by explaining the value it brings and the benefits they'll receive.",
        "Write a Twitter thread idea that will both go viral and attract high-quality leads for my [product/service] with a strong call-to-action and compelling visuals."
    };

    public async Task HandlePromptRequest(AIPromptPromptRequestEventArgs args)
    {
        args.Output = "do some work here";
        await Task.CompletedTask; // delete me after implmenting real work
    }
}