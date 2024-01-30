using ErrorOr;

namespace Fitfuel.Workouts.Domain.Common.Errors;

public static partial class Errors
{
    public static class Exercise
    {
        public static Error NotFound => Error.NotFound(
            code: "Exercise.NotFound",
            description: "Exercise not found in db.");
        
        public static Error DuplicateName => Error.Conflict(
            code: "Exercise.DuplicateName",
            description: "Duplicate name");
        
    }
}