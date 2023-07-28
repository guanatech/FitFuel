using Fitfuel.Workouts.Application.Common.Interfaces;
using Fitfuel.Workouts.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Fitfuel.Workouts.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IWorkoutPlanService, WorkoutPlanService>();
        services.AddScoped<IWorkoutService, WorkoutService>();
        services.AddScoped<IExerciseService, ExerciseService>();
        services.AddScoped<IEquipmentService, EquipmentService>();
       
        return services;
    }
}