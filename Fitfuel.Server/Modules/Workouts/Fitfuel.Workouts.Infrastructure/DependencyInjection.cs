using Fitfuel.Workouts.Application.Interfaces;
using Fitfuel.Workouts.Domain.WorkoutPlanAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fitfuel.Workouts.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, 
        ConfigurationManager configuration)
    {
        services
            .AddPersistence(configuration);
        
        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, 
        IConfiguration configuration)
    {
        return services;
    }
}