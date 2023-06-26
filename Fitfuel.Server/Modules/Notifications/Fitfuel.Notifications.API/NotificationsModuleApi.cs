using Fitfuel.Notifications.API.Services.Interfaces;
using Fitfuel.Notifications.Shared;

namespace Fitfuel.Notifications.API;

public class NotificationsModuleApi : INotificationsModuleApi
{
    private readonly IEmailSender _emailSender;

    public NotificationsModuleApi(IEmailSender emailSender)
    {
        _emailSender = emailSender;
    }

    public async Task SendEmailAsync(string email, string receiver, string message) =>
        await _emailSender.SendAsync(email, receiver, message);

}