using MiniNotificationApi.Interfaces;

namespace MiniNotificationApi.Services;

public class NotificationProviderB : INotificationProvider
{
    public Task<bool> SendAsync(string message, string recipient)
    {
        var provider = new NotificationProvider();
        return provider.SendAsync(message, recipient, 70);
    }
}