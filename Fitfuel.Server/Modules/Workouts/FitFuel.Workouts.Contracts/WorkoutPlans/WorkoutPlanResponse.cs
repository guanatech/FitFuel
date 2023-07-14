using FitFuel.Workouts.Contracts.Workouts;
using Fitfuel.Workouts.Domain.WorkoutPlanAggregate.Enums;

namespace FitFuel.Workouts.Contracts.WorkoutPlans;

public record WorkoutPlanResponse(
    string Name,
    Level Level,
    List<WorkoutResponse>? Workouts
);