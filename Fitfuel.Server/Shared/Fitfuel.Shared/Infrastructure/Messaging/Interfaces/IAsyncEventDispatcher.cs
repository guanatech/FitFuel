using Fitfuel.Shared.Events;

namespace Fitfuel.Shared.Infrastructure.Messaging.Interfaces;

public interface IAsyncEventDispatcher
{
    Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
        where TEvent : class, IEvent;
}