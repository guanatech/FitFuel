using ErrorOr;

namespace Fitfuel.Profiles.Domain.Common.Errors;

public static partial class Errors
{
    public static class Profile
    {
        public static Error NotFound => Error.NotFound(
            code: "Profile.NotFound",
            description: "Profile not found in database.");
        
        public static Error IncorrectWeightUnitFormat => Error.Validation(
            code: "Profile.IncorrectWeightUnitFormat",
            description: "Weight unit should be <Kg> or <Lb>.");
        
        public static Error IncorrectHeightUnitFormat => Error.Validation(
            code: "Profile.IncorrectHeightUnitFormat",
            description: "Height unit should be <Cm> or <Feet>.");
        
        public static Error IncorrectLevelValue => Error.Validation(
            code: "Profile.IncorrectLevelFormat",
            description: "Level should be one of these Beginner/Intermediate/Advance.");
    }
}