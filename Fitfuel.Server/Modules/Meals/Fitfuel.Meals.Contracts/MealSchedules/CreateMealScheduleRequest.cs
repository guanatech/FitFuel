namespace Fitfuel.Meals.Contracts.MealSchedules;

public record CreateMealScheduleRequest(
    string BreakfastTime, 
    string LunchTime, 
    string DinnerTime,
    Guid ProfileId,
    bool IsNotified);