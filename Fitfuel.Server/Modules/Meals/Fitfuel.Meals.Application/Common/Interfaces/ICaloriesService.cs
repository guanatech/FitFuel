using ErrorOr;
using Fitfuel.Meals.Contracts.Calories;
using Fitfuel.Meals.Domain.MealAggregate.ValueObjects;

namespace Fitfuel.Meals.Application.Common.Interfaces;

public interface ICaloriesService
{
    ErrorOr<double> GetDailyCaloriesCount(GetDailyCaloriesRequest request);

    ErrorOr<Nutrients> GetDailyNutrientsCount(GetDailyNutrientsRequest request);
}