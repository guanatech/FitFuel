namespace FitFuel.Workouts.Contracts.Workouts;

public record UpdateWorkoutRequest(
    Guid Id,
    string Name,
    Guid WorkoutPlanId,
    TimeSpan Duration,
    DateTime StartDate,
    string Description
);