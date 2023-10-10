namespace Fitfuel.Meals.Contracts.MealSchedules;

public record UpdateMealScheduleRequest(
    TimeSpan BreakfastTime, 
    TimeSpan LunchTime, 
    TimeSpan DinnerTime,
    Guid ProfileId,
    bool IsNotified);