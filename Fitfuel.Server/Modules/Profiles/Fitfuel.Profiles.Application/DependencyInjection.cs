using Fitfuel.Profiles.Application.Common.Interfaces;
using Fitfuel.Profiles.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Fitfuel.Profiles.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IProfilesService, ProfilesService>();
        services.AddScoped<IAchievementsService, AchievementsService>();
        return services;
    }
}