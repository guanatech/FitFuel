namespace FitFuel.Workouts.Contracts.Workouts;

public record WorkoutRequest(
    string Name,
    Guid WorkoutPlanId,
    DateTime StartDate,
    string Description
);