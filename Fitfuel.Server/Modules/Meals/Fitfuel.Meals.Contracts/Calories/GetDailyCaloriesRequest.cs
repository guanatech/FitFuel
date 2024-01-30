namespace Fitfuel.Meals.Contracts.Calories;

public record GetDailyCaloriesRequest(
    int Height, 
    double Weight, 
    int Age, 
    string Gender, 
    string Rate, 
    string? Target);