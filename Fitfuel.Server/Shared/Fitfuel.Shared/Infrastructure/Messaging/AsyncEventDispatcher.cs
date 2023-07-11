using Fitfuel.Shared.Events;
using Fitfuel.Shared.Infrastructure.Messaging.Interfaces;

namespace Fitfuel.Shared.Infrastructure.Messaging;

public class AsyncEventDispatcher : IAsyncEventDispatcher
{
    private readonly IEventChannel _channel;

    public AsyncEventDispatcher(IEventChannel channel)
    {
        _channel = channel;
    }

    public async Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default) 
        where TEvent : class, IEvent
    {
        await _channel.Writer.WriteAsync(@event, cancellationToken);
    }
}