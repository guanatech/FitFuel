using FitFuel.Workouts.Contracts.Exercises;

namespace FitFuel.Workouts.Contracts.Workouts;

public record WorkoutResponse(
   Guid Id,
   string Name,
   Guid WorkoutPlanId,
   TimeSpan Duration,
   DateTime StartDate,
   string Description,
   List<ExerciseResponse> Exercises
);