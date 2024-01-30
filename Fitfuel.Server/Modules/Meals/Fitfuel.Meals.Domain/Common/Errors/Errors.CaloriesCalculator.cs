using ErrorOr;

namespace Fitfuel.Meals.Domain.Common.Errors;

public static partial class Errors
{
    public static class CaloriesCalculator
    {
        public static Error IncorrectActivityRateType => Error.Conflict(
            code: "CaloriesCalculator.IncorrectActivityRateType",
            description: "ActivityRate enum type mismatched.");
        
        public static Error IncorrectTrainingTargetType => Error.Conflict(
            code: "CaloriesCalculator.IncorrectTrainingTargetType",
            description: "TrainingTarget enum type mismatched.");
    }
}