using Microsoft.Extensions.DependencyInjection;

namespace Fitfuel.Shared.Events;

internal sealed class EventDispatcher : IEventDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public EventDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    
    public async Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default) 
        where TEvent : class, IEvent
    {
        if (typeof(TEvent) == typeof(IEvent))
            await DispatchDynamicallyAsync(@event, cancellationToken);
        
        using var scope = _serviceProvider.CreateScope();
        var handlers = scope.ServiceProvider.GetServices<IEventHandler<TEvent>>();
        var tasks = handlers.Select(x => x.HandleAsync(@event, cancellationToken));
        await Task.WhenAll(tasks);
    }

    private async Task DispatchDynamicallyAsync(IEvent @event, CancellationToken cancellationToken = default)
    {
        using var scope = _serviceProvider.CreateScope();
        
        var handlerType = typeof(IEventHandler<>).MakeGenericType(@event.GetType());
        var handlers = scope.ServiceProvider.GetServices(handlerType);
        
        var method = handlerType.GetMethod(nameof(IEventHandler<IEvent>.HandleAsync))
            ?? throw new InvalidOperationException($"Event handler for '{@event.GetType().Name}' is invalid");

        var tasks = handlers.Select(h => (Task)method.Invoke(h, new object[] { @event, cancellationToken })!);
        await Task.WhenAll(tasks);
    }
}