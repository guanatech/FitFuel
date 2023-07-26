namespace Fitfuel.Meals.Contracts.Calories;

public record CalculateDailyCaloriesRequest(
    int Height, 
    double Weight, 
    int Age, 
    string Gender, 
    string Rate, 
    string? Target);