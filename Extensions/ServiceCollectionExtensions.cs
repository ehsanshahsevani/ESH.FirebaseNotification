namespace ESH.FirebaseNotification.Extensions;

using Services;
using Interfaces;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// متدهای توسعه برای افزودن سرویس نوتیفیکیشن به Dependency Injection.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// افزودن سرویس FirebaseNotificationService به Container Dependency Injection.
    /// </summary>
    /// <param name="services">کلکسیون سرویس‌ها.</param>
    /// <param name="firebaseConfigPath">مسیر فایل تنظیمات Firebase.</param>
    /// <returns>همان کلکسیون سرویس‌ها برای chain calling.</returns>
    public static IServiceCollection AddNotificationLibrary(
        this IServiceCollection services, string firebaseConfigPath)
    {
        services.AddSingleton<INotificationService>(provider =>
            new FirebaseNotificationService(firebaseConfigPath));
        
        return services;
    }
}