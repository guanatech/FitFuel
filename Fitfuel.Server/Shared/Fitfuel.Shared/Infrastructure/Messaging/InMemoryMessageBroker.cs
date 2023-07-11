using Fitfuel.Shared.Events;
using Fitfuel.Shared.Infrastructure.Messaging.Interfaces;
using Humanizer;
using Microsoft.Extensions.Logging;

namespace Fitfuel.Shared.Infrastructure.Messaging;

public class InMemoryMessageBroker : IMessageBroker
{
    private readonly IAsyncEventDispatcher _eventDispatcher;
    private readonly ILogger<InMemoryMessageBroker> _logger;

    public InMemoryMessageBroker(IAsyncEventDispatcher dispatcher, ILogger<InMemoryMessageBroker> logger)
    {
        _eventDispatcher = dispatcher;
        _logger = logger;
    }

    public async Task PublishAsync(IEvent @event, CancellationToken cancellationToken = default)
    {
        var name = @event.GetType().Name.Underscore();
        _logger.LogInformation("Publishing an event: {Name}...", name);
        await _eventDispatcher.PublishAsync(@event, cancellationToken);
    }
}