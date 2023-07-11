using Fitfuel.Shared.Events;

namespace Fitfuel.Shared.Infrastructure.Messaging.Interfaces;

public interface IMessageBroker
{
    Task PublishAsync(IEvent @event, CancellationToken cancellationToken = default);
}