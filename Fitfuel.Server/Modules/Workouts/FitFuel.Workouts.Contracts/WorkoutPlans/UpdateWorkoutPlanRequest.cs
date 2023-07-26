using Fitfuel.Workouts.Domain.WorkoutPlanAggregate.Enums;

namespace FitFuel.Workouts.Contracts.WorkoutPlans;

public record UpdateWorkoutPlanRequest(
    Guid Id,
    string Name,
    Level Level
);