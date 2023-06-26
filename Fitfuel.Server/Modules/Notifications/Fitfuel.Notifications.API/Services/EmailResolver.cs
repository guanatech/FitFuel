using Fitfuel.Notifications.API.Services.Interfaces;

namespace Fitfuel.Notifications.API.Services;

internal sealed class EmailResolver : IEmailResolver
{
    // TODO: Resolve the user/owner email address from other modules
    public string GetForOwner(Guid ownerId) => $"{ownerId:N}@fitfuel.com";
}