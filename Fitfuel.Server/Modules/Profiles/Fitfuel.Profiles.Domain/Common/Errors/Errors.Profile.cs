using ErrorOr;

namespace Fitfuel.Profiles.Domain.Common.Errors;

public static partial class Errors
{
    public static class Profile
    {
        public static Error NotFound => Error.NotFound(
            code: "Profile.NotFound",
            description: "Profile not found in database.");
    }
}