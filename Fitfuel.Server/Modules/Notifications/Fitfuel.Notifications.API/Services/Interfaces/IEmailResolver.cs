namespace Fitfuel.Notifications.API.Services.Interfaces;

public interface IEmailResolver
{
    string GetForOwner(Guid ownerId);
}