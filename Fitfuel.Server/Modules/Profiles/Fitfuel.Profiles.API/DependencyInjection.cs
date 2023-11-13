using Fitfuel.Profiles.Application;
using Fitfuel.Profiles.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Fitfuel.Profiles.API;

public static class DependencyInjection
{
    public static IServiceCollection AddProfilesModule(this IServiceCollection services)
    {
        services
            .AddApplication()
            .AddInfrastructure();

        return services;
    }
}