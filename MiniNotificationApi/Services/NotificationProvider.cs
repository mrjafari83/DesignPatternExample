namespace MiniNotificationApi.Services;

internal class NotificationProvider
{
    internal static Random Random = new Random();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    /// <param name="recipient"></param>
    /// <param name="successRate"></param>
    /// <returns></returns>
    public async Task<bool> SendAsync(string message, string recipient, int successRate)
    {
        await Task.Delay(1);
        return Random.Next(100) <= successRate;
    }
}