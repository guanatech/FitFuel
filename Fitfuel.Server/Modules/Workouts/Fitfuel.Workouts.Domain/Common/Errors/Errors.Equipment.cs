using ErrorOr;

namespace Fitfuel.Workouts.Domain.Common.Errors;

public static partial class Errors
{
    public static class Equipment
    {
        public static Error NotFound => Error.NotFound(
            code: "Equipment.NotFound",
            description: "Equipment not found in db.");
        
        public static Error DuplicateName => Error.Conflict(
            code: "Equipment.DuplicateName",
            description: "Duplicate name");
        
    }
}