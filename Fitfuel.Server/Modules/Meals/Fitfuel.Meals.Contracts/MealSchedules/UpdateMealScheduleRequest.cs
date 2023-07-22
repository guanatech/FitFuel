namespace Fitfuel.Meals.Contracts.MealSchedules;

public record UpdateMealScheduleRequest(
    string BreakfastTime, 
    string LunchTime, 
    string DinnerTime,
    bool IsNotified);