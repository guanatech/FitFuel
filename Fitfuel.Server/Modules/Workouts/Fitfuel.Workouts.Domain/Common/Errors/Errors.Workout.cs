using ErrorOr;

namespace Fitfuel.Workouts.Domain.Common.Errors;

public static partial class Errors
{
    public static class Workout
    {
        public static Error NotFound => Error.NotFound(
            code: "Workout.NotFound",
            description: "Workout not found in db.");
        
        public static Error DuplicateName => Error.Conflict(
            code: "Workout.DuplicateName",
            description: "Duplicate name");
        
    }
}