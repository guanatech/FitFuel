using Fitfuel.Meals.Domain.Common.Enums;
using Fitfuel.Meals.Domain.MealAggregate.ValueObjects;

namespace Fitfuel.Meals.Application.Common.Interfaces;

public interface ICaloriesCalculator
{
    double GetDailyCalorieCount(int height, double weight, int age, string gender, ActivityRate rate, 
        TrainingTarget? target);

    Nutrients GetDailyNutrientsCount(double dailyCalorieCount, TrainingTarget target);
}