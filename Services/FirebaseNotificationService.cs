using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using ESH.FirebaseNotification.Interfaces;

namespace ESH.FirebaseNotification.Services;


/// <summary>
/// پیاده‌سازی سرویس ارسال نوتیفیکیشن با استفاده از Firebase Cloud Messaging.
/// </summary>
public class FirebaseNotificationService : INotificationService
{
    /// <summary>7
    /// مقدار پیش‌فرض برای سرویس FirebaseNotificationService.
    /// </summary>
    public FirebaseNotificationService(string firebaseConfigPath)
    {
        if (FirebaseApp.DefaultInstance == null)
        {
            FirebaseApp.Create(new AppOptions
            {
                Credential = GoogleCredential.FromFile(firebaseConfigPath)
            });
        }
    }

    /// <summary>
    /// ارسال پیام نوتیفیکیشن به یک دستگاه خاص.
    /// </summary>
    /// <param name="notification">مدل نوتیفیکیشن که شامل اطلاعات پیام است.</param>
    /// <returns>یک تسک که نشان‌دهنده تکمیل ارسال پیام است.</returns>
    public async Task SendNotificationAsync(Models.Notification notification)
    {
        if (notification == null)
        {
            throw new ArgumentNullException(nameof(notification));
        }

        var message = new Message
        {
            Notification = new FirebaseAdmin.Messaging.Notification
            {
                Title = notification.Title,
                Body = notification.Body
            },
            Token = notification.DeviceToken
        };

        await FirebaseMessaging.DefaultInstance.SendAsync(message);
    }
}