using Fitfuel.Profiles.Infrastructure.Persistence;
using Fitfuel.Shared.Infrastructure.Persistence.Abstractions;
using Fitfuel.Shared.Infrastructure.Persistence.Database;
using Microsoft.Extensions.DependencyInjection;

namespace Fitfuel.Profiles.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddPersistence();
        return services;
    }
    
    private static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddPostgres<ProfilesDbContext>();
        services.AddScoped(typeof(IRepository<>),typeof(ProfilesRepository<>));
        return services;
    }
}