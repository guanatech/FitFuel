using ErrorOr;

namespace Fitfuel.Notifications.API.Services.Interfaces;

public interface IEmailSender
{
    Task<ErrorOr<Success>> SendAsync(string email, string subject, string message);
}