using Fitfuel.Shared.Infrastructure.Persistence.Database;
using Fitfuel.Workouts.Application;
using Fitfuel.Workouts.Infrastructure;
using Fitfuel.Workouts.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fitfuel.Workouts.API;

public static class DependencyInjection 
{
    public static IServiceCollection AddWorkoutsModule(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddApplication()
            .AddInfrastructure();

        return services;
    }
}