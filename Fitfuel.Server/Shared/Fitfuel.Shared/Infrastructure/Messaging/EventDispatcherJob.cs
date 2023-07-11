using Fitfuel.Shared.Events;
using Fitfuel.Shared.Infrastructure.Messaging.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Fitfuel.Shared.Infrastructure.Messaging;

public class EventDispatcherJob : BackgroundService
{
    private readonly IEventChannel _channel;
    private readonly IEventDispatcher _eventDispatcher;
    private readonly ILogger<EventDispatcherJob> _logger;

    public EventDispatcherJob(IEventChannel channel, IEventDispatcher dispatcher, ILogger<EventDispatcherJob> logger)
    {
        _channel = channel;
        _eventDispatcher = dispatcher;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await foreach (var @event in _channel.Reader.ReadAllAsync(stoppingToken))
        {
            try
            {
                await _eventDispatcher.PublishAsync(@event, stoppingToken);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Reason: {Reason}", exception.Message);
            }
        }
    }
}