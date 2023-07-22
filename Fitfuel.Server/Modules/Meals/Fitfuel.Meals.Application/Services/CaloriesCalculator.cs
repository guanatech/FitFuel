using Fitfuel.Meals.Application.Common.Interfaces;
using Fitfuel.Meals.Domain.Common.Enums;
using Fitfuel.Meals.Domain.MealAggregate.ValueObjects;

namespace Fitfuel.Meals.Application.Services;

public class CaloriesCalculator : ICaloriesCalculator
{
    public double GetDailyCalorieCount(int height, double weight, int age, string gender, ActivityRate rate,
        TrainingTarget? target)
    {
        var rateValue = GetPhysicalActivityRate(rate);
        var calorieCount = gender switch
        {
            "Man" => rateValue * (66.5 + (13.75 * weight) + (5.003 * height) - (6.775 * age)),
            "Woman" => rateValue * (655.1 + (9.563 * weight) + (1.85 * height) - (4.676 * age)),
            _ => 0
        };

        var resultCount = target switch
        {
            TrainingTarget.ShapeMaintenance => calorieCount,
            TrainingTarget.WeightGain => calorieCount + calorieCount * 0.1,
            TrainingTarget.WeightLoss => calorieCount - calorieCount * 0.1,
            _ => calorieCount
        };

        return resultCount;
    }
    
    public Nutrients GetDailyNutrientsCount(double dailyCalorieCount, TrainingTarget target)
    {
        var nutrients = target switch
        {
            TrainingTarget.ShapeMaintenance => new Nutrients(proteins: dailyCalorieCount*0.2/4, // 20/30/50
                fats: dailyCalorieCount*0.3/9, 
                carbs: dailyCalorieCount*0.5/4),
            TrainingTarget.WeightGain => new Nutrients(proteins: dailyCalorieCount*0.35/4, // 35/20/55
                fats: dailyCalorieCount*0.2/9, 
                carbs: dailyCalorieCount*0.55/4),
            TrainingTarget.WeightLoss => new Nutrients(proteins: dailyCalorieCount*0.25/4, // 25/30/45
                fats: dailyCalorieCount*0.3/9, 
                carbs: dailyCalorieCount*0.45/4),
            _ => throw new ArgumentOutOfRangeException()
        };
        return nutrients;
    }

    private double GetPhysicalActivityRate(ActivityRate rate)
    {
        return rate switch
        {
            ActivityRate.None => 1,
            ActivityRate.Low => 1.2,
            ActivityRate.Minimal => 1.375,
            ActivityRate.Middle => 1.55,
            ActivityRate.High => 1.7,
            ActivityRate.Extreme => 1.9,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}