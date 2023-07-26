using Fitfuel.Shared.Infrastructure.Abstractions;
using Fitfuel.Workouts.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Fitfuel.Workouts.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services
            .AddPersistence();
        
        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        
        services.AddScoped(typeof(IRepository<>),typeof(WorkoutsRepository<>));
        return services;
    }
}