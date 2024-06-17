namespace TelerikBlazorApp1.Client.Features.OpenAI.Services;

public record AiOutput(string Title, string Output, DateTime Timestamp);

public class ConversationState
{
    private SortedDictionary<DateTime, AiOutput> Outputs { get; } = new();

    public IEnumerable<AiOutput> ChatHistory => Outputs.Values;

    public IEnumerable<AiOutput> Add(AiOutput aiOutput)
    {
        Outputs.Add(aiOutput.Timestamp, aiOutput);
        return Outputs.Values;
    }
}