//builder.Services.AddScoped<IOpenAiService, OpenAiService>();

// OpenAI proxy
app.MapPost($"/openai", async (
    [FromBody] string prompt,
    [FromServices] IOpenAiService openAi) =>
     await openAi.MakeAiRequest(prompt)
     );

