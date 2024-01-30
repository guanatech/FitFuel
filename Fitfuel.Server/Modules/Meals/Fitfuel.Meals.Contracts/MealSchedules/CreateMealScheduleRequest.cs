namespace Fitfuel.Meals.Contracts.MealSchedules;

public record CreateMealScheduleRequest(
    TimeSpan BreakfastTime, 
    TimeSpan LunchTime, 
    TimeSpan DinnerTime,
    Guid ProfileId,
    bool IsNotified);