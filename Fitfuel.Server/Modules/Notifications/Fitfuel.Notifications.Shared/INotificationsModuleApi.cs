namespace Fitfuel.Notifications.Shared;

public interface INotificationsModuleApi
{
    Task SendEmailAsync(string email, string receiver, string message);
}