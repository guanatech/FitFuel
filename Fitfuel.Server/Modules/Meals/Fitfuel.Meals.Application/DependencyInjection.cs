using Fitfuel.Meals.Application.Common.Interfaces;
using Fitfuel.Meals.Application.Services;
using Fitfuel.Meals.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Fitfuel.Meals.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IMealSchedulesService, MealSchedulesService>();
        services.AddScoped<ICaloriesService, CaloriesService>();
        services.AddScoped<CaloriesCalculator>();
        return services;
    }
}