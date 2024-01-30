using ErrorOr;

namespace Fitfuel.Profiles.Domain.Common.Errors;

public static partial class Errors
{
    public static class Achievement
    {
        public static Error NameAlreadyExists => Error.Conflict(
            code: "Achievement.AlreadyExists",
            description: "Achievement with same name already exists in database.");
        
        public static Error NotFound => Error.NotFound(
            code: "Achievement.NotFound",
            description: "Achievement not found in database.");
    }
}