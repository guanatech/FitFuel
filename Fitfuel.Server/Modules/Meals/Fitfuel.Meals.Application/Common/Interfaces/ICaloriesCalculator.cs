namespace Fitfuel.Meals.Application.Common.Interfaces;

public interface ICaloriesCalculator
{
    double GetDailyCalorieCount(int height, int weight, int age);
}