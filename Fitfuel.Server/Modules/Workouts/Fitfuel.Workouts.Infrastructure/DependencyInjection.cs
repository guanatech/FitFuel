using Fitfuel.Shared.Infrastructure.Persistence.Abstractions;
using Fitfuel.Shared.Infrastructure.Persistence.Database;
using Fitfuel.Workouts.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Fitfuel.Workouts.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        return AddPersistence(services);
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddPostgres<WorkoutsDbContext>();  
        services.AddScoped(typeof(IRepository<>),typeof(WorkoutsRepository<>));
        return services;
    }
}