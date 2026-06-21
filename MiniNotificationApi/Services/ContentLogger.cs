using MiniNotificationApi.Interfaces;

namespace MiniNotificationApi.Services;

internal class ContentLogger(IEnumerable<IContentLoggerProvider> loggerProviders) : IContentLogger
{
    public void Log(string content)
    {
        foreach (var contentLoggerProvider in loggerProviders)
        {
            contentLoggerProvider.Log(content);
        }
    }
}