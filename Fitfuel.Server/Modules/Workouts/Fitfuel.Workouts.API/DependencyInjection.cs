using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fitfuel.Workouts.API;

public static class DependencyInjection
{
    public static IServiceCollection AddWorkoutsModule(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}