namespace Fitfuel.Meals.Contracts.Calories;

public record GetDailyNutrientsRequest(
    double DailyCalorieCount, 
    string TrainingTarget);
