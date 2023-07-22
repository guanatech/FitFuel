namespace Fitfuel.Meals.Contracts.MealSchedules;

public record UpdateMealScheduleRequest(
    Guid Id,
    string BreakfastTime, 
    string LunchTime, 
    string DinnerTime,
    Guid ProfileId,
    bool IsNotified);