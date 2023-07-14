using ErrorOr;

namespace Fitfuel.Workouts.Domain.Common.Errors;

public static partial class Errors
{
    public static class WorkoutPlan
    {
        public static Error NotFound => Error.NotFound(
            code: "WorkoutPlan.NotFound",
            description: "Workout plan not found in db.");
        
        public static Error DuplicateName => Error.Conflict(
            code: "WorkoutPlan.DuplicateName",
            description: "Duplicate name");
        
    }
}