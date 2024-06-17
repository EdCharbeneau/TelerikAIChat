using BlazorComponentUtilities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TelerikBlazorApp1.Client.Services;
public class ThemeState
{
    private string themeColor = "#003366";

    public event Action? OnChange;
    public string ThemeColor => themeColor;
    public void SetThemeColor(string newTheme)
    {
        themeColor = newTheme;
        OnChange?.Invoke(); ;
    }

    public static StyleBuilder CreateTheme(string accentColor) => StyleBuilder.Empty()
.AddStyle("--kendo-color-primary", accentColor)
.AddStyle(ThemeSettings());

    private static StyleBuilder ThemeSettings() => StyleBuilder.Empty()
.AddStyle("--kendo-color-primary-subtle", "color-mix(in srgb, var(--kendo-color-primary), white 75%)")
    .AddStyle("--kendo-color-primary-subtle-hover", "color-mix(in srgb, var(--kendo-color-primary), white 50%)")
    .AddStyle("--kendo-color-primary-subtle-active", "color-mix(in srgb, var(--kendo-color-primary), white)")
    .AddStyle("--kendo-color-primary-hover", "color-mix(in srgb, var(--kendo-color-primary), black)")
    .AddStyle("--kendo-color-primary-active", "color-mix(in srgb, var(--kendo-color-primary), black 75%)")
    .AddStyle("--kendo-color-primary-emphasis", "color-mix(in srgb, var(--kendo-color-primary), white)")
    .AddStyle("--kendo-color-primary-on-subtle", " color-mix(in srgb, var(--kendo-color-primary), white)")
    .AddStyle("--kendo-color-on-primary", "#ffffff")
    .AddStyle("--kendo-color-primary-on-surface", "color-mix(in srgb, var(--kendo-color-primary), white)")
    .AddStyle("--kendo-card-header-text", "var(--kendo-color-on-primary)")
    .AddStyle("--kendo-card-subtitle-text", "var(--kendo-color-on-primary)")
    .AddStyle("--kendo-card-border", "var(--kendo-color-primary)")
    ;
}
