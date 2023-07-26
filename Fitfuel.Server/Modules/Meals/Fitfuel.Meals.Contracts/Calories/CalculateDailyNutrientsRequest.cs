namespace Fitfuel.Meals.Contracts.Calories;

public record CalculateDailyNutrientsRequest(
    double DailyCalorieCount, 
    string TrainingTarget);
