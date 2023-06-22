using Fitfuel.Meals.Infrastructure.Persistence;
using Fitfuel.Shared.Infrastructure.Persistence.Database;
using Microsoft.Extensions.DependencyInjection;

namespace Fitfuel.Meals.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddPostgres<MealsDbContext>();
        return services;
    }
}