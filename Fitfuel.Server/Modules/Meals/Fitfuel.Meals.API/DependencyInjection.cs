using Fitfuel.Meals.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fitfuel.Meals.API;

public static class DependencyInjection
{
    public static IServiceCollection AddMealsModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructure();

        return services;
    }
}