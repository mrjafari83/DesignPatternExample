using MiniNotificationApi.Interfaces;

namespace MiniNotificationApi.Services;

internal class NotificationSender : INotificationSender
{
    private readonly IEnumerable<INotificationProvider> _notificationProviders;
    private readonly IContentLogger _contentLogger;

    public NotificationSender(IEnumerable<INotificationProvider> notificationProviders, IContentLogger contentLogger)
    {
        _notificationProviders = notificationProviders;
        _contentLogger = contentLogger;
    }

    public async Task<bool> SendAsync(string message, string recipient)
    {
        _contentLogger.Log($"Start selecting provider and sending notification...");
        foreach (var notificationProvider in _notificationProviders.OrderBy(_ => Guid.NewGuid()))
        {
            var providerName = notificationProvider.GetType().Name;
            _contentLogger.Log($"{providerName} selected as provider");

            var sendResult = await notificationProvider.SendAsync(message, recipient);
            if (sendResult)
            {
                _contentLogger.Log($"Notification successfully sent by {providerName}");
                return true;
            }

            _contentLogger.Log($"Sending by {providerName} provider failed");
        }

        _contentLogger.Log($"All {_notificationProviders.Count()}providers are unavailable");
        return false;
    }
}