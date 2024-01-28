using ErrorOr;

namespace Fitfuel.Meals.Domain.Common.Errors;

public static partial class Errors
{
    public static class Meal 
    {
        public static Error IncorrectMealCategory => Error.Validation(
            code: "Meal.IncorrectMealCategory",
            description: "No such meal category has been defined.");
    }
}