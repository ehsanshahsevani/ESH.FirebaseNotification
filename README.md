
# 📚 ESH.FirebaseNotification

این لایبرری برای ارسال نوتیفیکیشن‌ها از طریق **Firebase Cloud Messaging (FCM)** طراحی شده است. شما می‌توانید به راحتی این لایبرری را در پروژه‌های مختلف خود برای ارسال نوتیفیکیشن‌ها به دستگاه‌های موبایل از طریق Firebase استفاده کنید.

---

## 🚀 شروع سریع

برای استفاده از این لایبرری، کافی است که پکیج را به پروژه خود اضافه کرده و تنظیمات اولیه را انجام دهید.

### 1. نصب پکیج

برای نصب این لایبرری از NuGet استفاده کنید. دستور زیر را در کنسول **NuGet** وارد کنید:

```bash
dotnet add package ESH.FirebaseNotification
```

### 2. تنظیمات اولیه

برای راه‌اندازی Firebase، فایل پیکربندی Firebase (`firebase-config.json`) را از Firebase Console دریافت کرده و آن را در مسیر مشخص قرار دهید. سپس این مسیر را هنگام تنظیم سرویس در پروژه خود وارد کنید.

```csharp
using Microsoft.Extensions.DependencyInjection;
using ESH.FirebaseNotification.Extensions;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // مسیر فایل پیکربندی Firebase
        string firebaseConfigPath = "configs/firebase-config.json";
        
        // افزودن سرویس نوتیفیکیشن
        services.AddEshFirebaseNotification(firebaseConfigPath);
    }
}
```

---

## 🧑‍💻 ویژگی‌ها

این لایبرری ویژگی‌های زیر را ارائه می‌دهد:

- **ارسال نوتیفیکیشن به یک دستگاه خاص**: ارسال نوتیفیکیشن به یک دستگاه مشخص با استفاده از **Device Token**.
- **پشتیبانی از Firebase Admin SDK**: استفاده از Firebase Admin SDK برای ارسال نوتیفیکیشن‌ها به دستگاه‌های موبایل.
- **سفارشی‌سازی پیام نوتیفیکیشن**: امکان تعیین عنوان، متن و توکن دستگاه گیرنده.

---

## ⚙️ نحوه استفاده

### 1. ارسال نوتیفیکیشن به یک دستگاه خاص

برای ارسال نوتیفیکیشن به یک دستگاه خاص، باید از متد `SendNotificationAsync` استفاده کنید و توکن دستگاه را به همراه عنوان و متن پیام ارسال کنید.

```csharp
public class FirebaseNotificationService : INotificationService
{
    public async Task SendNotificationAsync(Notification notification)
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
```

### 2. افزودن سرویس نوتیفیکیشن به Dependency Injection

برای استفاده از این سرویس در پروژه‌های ASP.NET Core، کافی است سرویس `FirebaseNotificationService` را به **Dependency Injection** اضافه کنید.

```csharp
namespace ESH.FirebaseNotification.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEshFirebaseNotification(
            this IServiceCollection services, string firebaseConfigPath)
        {
            services.AddSingleton<INotificationService>(provider =>
                new FirebaseNotificationService(firebaseConfigPath));
            
            return services;
        }
    }
}
```

---

## 🛠️ تنظیمات پیشرفته

### 1. پیکربندی مسیر فایل تنظیمات Firebase

در کلاس `Startup.cs`، مسیر فایل `firebase-config.json` را به روش زیر وارد کنید:

```csharp
string firebaseConfigPath = "configs/firebase-config.json";
```

### 2. ارسال نوتیفیکیشن به گروهی از دستگاه‌ها

می‌توانید از **topics** برای ارسال نوتیفیکیشن به گروهی از دستگاه‌ها استفاده کنید. به این ترتیب، نیازی به دانستن توکن هر دستگاه نخواهید داشت:

```csharp
public async Task SendNotificationToTopicAsync(string topic, string title, string body)
{
    var message = new Message()
    {
        Topic = topic,
        Notification = new FirebaseAdmin.Messaging.Notification
        {
            Title = title,
            Body = body
        }
    };

    await FirebaseMessaging.DefaultInstance.SendAsync(message);
}
```

---

## 🌐 همکاری و مشارکت

اگر تمایل دارید به این پروژه کمک کنید، می‌توانید آن را از طریق **GitHub** مشاهده کنید و پیشنهادات خود را به اشتراک بگذارید.

🔗 **GitHub**: [github.com/ehsanshahsevani/ESH.FirebaseNotification](https://github.com/ehsanshahsevani/ESH.FirebaseNotification)

---

## 📧 ارتباط با ما

برای هر گونه سوال یا پیشنهاد، می‌توانید از طریق ایمیل یا **GitHub Issues** با ما در ارتباط باشید:

📧 **Email**: ShahsevaniEhsan@gmail.com

---

## 📝 مجوز

این پروژه تحت **مجوز MIT** منتشر شده است.

---

### نکات مهم:
- این لایبرری به شما امکان ارسال نوتیفیکیشن‌های شخصی‌سازی شده به دستگاه‌های مختلف از طریق Firebase را می‌دهد.
- در این داکیومنت از ایموجی‌ها برای جذاب‌تر کردن توضیحات استفاده شده است.
- به مستندسازی دقیق کلاس‌ها و متدها توجه کرده‌ایم تا استفاده از لایبرری برای توسعه‌دهندگان ساده باشد.
