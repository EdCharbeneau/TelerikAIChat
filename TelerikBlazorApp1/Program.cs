using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;
using TelerikBlazorApp1;
using TelerikBlazorApp1.Client;
using TelerikBlazorApp1.Client.Pages;
using TelerikBlazorApp1.Client.Services;
using TelerikBlazorApp1.Components;
using TelerikBlazorApp1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IOpenAiService, OpenAiService>();
builder.Services.AddScoped<ConversationState>();

// Add services to the container.
builder.Services.AddRazorComponents()
    //.AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddTelerikBlazor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    //.AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Counter).Assembly);

app.MapApplicationEndpoints();

app.Run();

