using Fitfuel.Shared.Infrastructure.Messaging;
using Fitfuel.Shared.Infrastructure.Messaging.Interfaces;
using Fitfuel.Shared.Infrastructure.Persistence.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Fitfuel.Shared.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration,
        IHostBuilder host)
    {
        services.AddPostgres(configuration);
        services.AddLogging(configuration, host);
        services.AddMessaging();
        
        return services;
    }
    
    private static void AddLogging(this IServiceCollection services, IConfiguration configuration,
        IHostBuilder host)
    {
        var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();

        host.UseSerilog(logger);
    }
    
    private static void AddMessaging(this IServiceCollection services)
    {
        services.AddTransient<IMessageBroker, InMemoryMessageBroker>();
        services.AddTransient<IAsyncEventDispatcher, AsyncEventDispatcher>();
        services.AddSingleton<IEventChannel, EventChannel>();
        services.AddHostedService<EventDispatcherJob>();
    }
}