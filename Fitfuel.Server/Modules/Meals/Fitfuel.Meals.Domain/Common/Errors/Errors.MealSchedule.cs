using ErrorOr;

namespace Fitfuel.Meals.Domain.Common.Errors;

public static partial class Errors
{
    public static class MealSchedule
    {
        public static Error MealScheduleNotFound => Error.NotFound(
            code: "MealSchedule.NotFound",
            description: "MealSchedule not found in db.");
        
        public static Error MealScheduleAlreadyExist => Error.Conflict(
            code: "MealSchedule.AlreadyExist",
            description: "MealSchedule already exist for this user.");
    }
}