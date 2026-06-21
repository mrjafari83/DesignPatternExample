namespace MiniNotificationApi.Interfaces;

public interface INotificationProvider
{
    public Task<bool> SendAsync(string message, string recipient);
}