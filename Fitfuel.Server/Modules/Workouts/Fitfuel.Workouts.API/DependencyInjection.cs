using Fitfuel.Workouts.Application;
using Fitfuel.Workouts.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Fitfuel.Workouts.API;

public static class DependencyInjection 
{
    public static IServiceCollection AddWorkoutsModule(this IServiceCollection services)
    {
        services
            .AddApplication()
            .AddInfrastructure();
        

        return services;
    }
}