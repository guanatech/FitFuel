using Fitfuel.Workouts.Domain.WorkoutPlanAggregate;
using Fitfuel.Workouts.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        
        services.AddScoped(typeof(WorkoutsRepository<>));
        return services;
    }
}