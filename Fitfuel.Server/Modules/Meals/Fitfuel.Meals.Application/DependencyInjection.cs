using Fitfuel.Meals.Application.Common.Interfaces;
using Fitfuel.Meals.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Fitfuel.Meals.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IMealSchedulesService, MealSchedulesService>();
        services.AddScoped<ICaloriesCalculator, CaloriesCalculator>();
        return services;
    }
}