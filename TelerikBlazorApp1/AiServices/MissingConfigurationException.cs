using System.Runtime.Serialization;

namespace TelerikBlazorApp1.Services;

[Serializable]
internal class MissingConfigurationException : Exception
{
    private static readonly string DefaultMessage = "Configuration was not set for this application. Please check your application settings, user secrets, or enviornment variables.";
    public MissingConfigurationException() : base(DefaultMessage) { }

    public MissingConfigurationException(string? message) : base(message) { }

    public MissingConfigurationException(string? message, Exception? innerException) : base(message, innerException) { }

}
