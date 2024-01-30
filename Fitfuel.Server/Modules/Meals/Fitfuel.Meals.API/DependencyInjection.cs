using Fitfuel.Meals.Application;
using Fitfuel.Meals.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Fitfuel.Meals.API;

public static class DependencyInjection
{
    public static IServiceCollection AddMealsModule(this IServiceCollection services)
    {
        services
            .AddApplication()
            .AddInfrastructure();

        return services;
    }
}