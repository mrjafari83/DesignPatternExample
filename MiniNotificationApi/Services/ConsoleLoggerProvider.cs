using MiniNotificationApi.Interfaces;

namespace MiniNotificationApi.Services;

internal class ConsoleLoggerProvider : IContentLoggerProvider
{
    public void Log(string content)
    {
        Console.WriteLine($"NewContent:\t{content}");
    }
}