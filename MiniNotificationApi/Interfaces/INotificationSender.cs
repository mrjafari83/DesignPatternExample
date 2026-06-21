namespace MiniNotificationApi.Interfaces
{
    public interface INotificationSender
    {
        public Task<bool> SendAsync(string message, string recipient);
    }
}
