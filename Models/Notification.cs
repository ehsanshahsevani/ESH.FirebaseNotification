namespace ESH.FirebaseNotification.Models;

/// <summary>
/// نماینده یک پیام نوتیفیکیشن برای ارسال به دستگاه‌های کلاینت.
/// </summary>
public class Notification : object
{
    /// <summary>
    /// مقدار پیش‌فرض برای ساخت یک پیام نوتیفیکیشن.
    /// </summary>
    public Notification()
    {
        Title = string.Empty;
        Body = string.Empty;
        DeviceToken = string.Empty;
    }

    /// <summary>
    /// عنوان نوتیفیکیشن.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// متن اصلی پیام نوتیفیکیشن.
    /// </summary>
    public string Body { get; set; }

    /// <summary>
    /// توکن دستگاه گیرنده پیام.
    /// </summary>
    public string DeviceToken { get; set; }
}