using ErrorOr;

namespace Fitfuel.Meals.Domain.Common.Errors;

public static partial class Errors
{
    public static class MealSchedule
    {
        public static Error MealScheduleNotFound => Error.NotFound(
            code: "MealSchedule.NotFound",
            description: "MealSchedule not found in db.");
    }
}