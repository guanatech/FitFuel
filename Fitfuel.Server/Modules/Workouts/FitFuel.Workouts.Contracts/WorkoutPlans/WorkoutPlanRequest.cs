using Fitfuel.Workouts.Domain.WorkoutPlanAggregate.Enums;

namespace FitFuel.Workouts.Contracts.WorkoutPlans;

public record WorkoutPlanRequest(
    string Name,
    Level Level
);