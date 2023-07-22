namespace Fitfuel.Meals.Contracts.MealSchedules;

public record UpdateMealScheduleRequest(
    Guid Id,
    TimeSpan BreakfastTime, 
    TimeSpan LunchTime, 
    TimeSpan DinnerTime,
    Guid ProfileId,
    bool IsNotified);