using ErrorOr;
using Fitfuel.Meals.Application.Common.Interfaces;
using Fitfuel.Meals.Contracts.Calories;
using Fitfuel.Meals.Domain;
using Fitfuel.Meals.Domain.MealAggregate.ValueObjects;

namespace Fitfuel.Meals.Application.Services;

public class CaloriesService : ICaloriesService
{
    private readonly CaloriesCalculator _caloriesCalculator;

    public CaloriesService(CaloriesCalculator caloriesCalculator)
    {
        _caloriesCalculator = caloriesCalculator;
    }

    public ErrorOr<double> GetDailyCaloriesCount(GetDailyCaloriesRequest request)
    {
        var result = _caloriesCalculator.CalculateDailyCaloriesCount(request.Height, request.Weight, request.Age, 
            request.Gender, request.Rate, request.Target);
        return result;
    }

    public ErrorOr<Nutrients> GetDailyNutrientsCount(GetDailyNutrientsRequest request)
    {
        var result =
            _caloriesCalculator.CalculateDailyNutrientsCount(request.DailyCalorieCount, request.TrainingTarget);
        return result;
    }
}