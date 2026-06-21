using Microsoft.AspNetCore.Mvc;
using MiniNotificationApi.Interfaces;

namespace MiniNotificationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationsController(INotificationSender notificationSender,
        IContentLogger contentLogger) : ControllerBase
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> PushNotification([FromForm] string message, [FromForm] string recipient,
            CancellationToken cancellationToken)
        {
            contentLogger.Log($"New notification received, Message : '{message}', Recipient : '{recipient}'");
            var result = await notificationSender.SendAsync(message, recipient);
            if (result)
                return Ok(new
                {
                    Message = "اعلان با موفقیت ارسال شد"
                });
            return BadRequest(new
            {
                Message = "هنگام ارسال اعلان خطایی رخ داده است، لطفا مجدد تلاش کنید"
            });
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SendOtp([FromForm] string recipient,
            CancellationToken cancellationToken)
        {
            var random = new Random();
            var code = random.Next(100_000, 999_999);
            var message = $":کد احرازهویت شما عبارت است از {code}";
            contentLogger.Log($"New otp received, Message : '{message}', Recipient : '{recipient}', Code : '{code}'");

            var result = await notificationSender.SendAsync(message, recipient);
            if (result)
                return Ok(new
                {
                    Message = $"اعلان با موفقیت ارسال شد، کد تولید شده : {code}"
                });
            return BadRequest(new
            {
                Message = "هنگام ارسال اعلان خطایی رخ داده است، لطفا مجدد تلاش کنید"
            });
        }
    }
}
