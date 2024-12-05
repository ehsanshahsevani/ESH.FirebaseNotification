using ESH.FirebaseNotification.Models;

namespace ESH.FirebaseNotification.Interfaces;

/// <summary>
/// تعریف عملکردهای اصلی برای ارسال نوتیفیکیشن‌ها.
/// </summary>
public interface INotificationService
{
    /// <summary>
    /// ارسال پیام نوتیفیکیشن به یک دستگاه.
    /// </summary>
    /// <param name="notification">مدل نوتیفیکیشن که شامل اطلاعات پیام است.</param>
    /// <returns>یک تسک که نشان‌دهنده تکمیل ارسال پیام است.</returns>
    Task SendNotificationAsync(Notification notification);
}