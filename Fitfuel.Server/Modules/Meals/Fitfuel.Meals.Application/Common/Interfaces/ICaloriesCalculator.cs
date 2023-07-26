using ErrorOr;
using Fitfuel.Meals.Contracts.Calories;
using Fitfuel.Meals.Domain.MealAggregate.ValueObjects;

namespace Fitfuel.Meals.Application.Common.Interfaces;

public interface ICaloriesCalculator
{
    ErrorOr<double> GetDailyCaloriesCount(CalculateDailyCaloriesRequest request);

    ErrorOr<Nutrients> GetDailyNutrientsCount(CalculateDailyNutrientsRequest request);
}