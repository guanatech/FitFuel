using ErrorOr;
using Fitfuel.Meals.Domain.Common.Enums;
using Fitfuel.Meals.Domain.Common.Errors;
using Fitfuel.Meals.Domain.MealAggregate.ValueObjects;

namespace Fitfuel.Meals.Domain.DomainServices;

public class CaloriesCalculator
{
    public ErrorOr<double> CalculateDailyCaloriesCount(int height, double weight, int age, string gender, 
        string rate, string? target = null)
    {
        var rateResult = GetPhysicalActivityRate(rate);
        
        if (rateResult.IsError)
            return rateResult.FirstError;
        
        var calorieCount = gender switch
        {
            "Man" => rateResult.Value * (66.5 + (13.75 * weight) + 
                (5.003 * height) - (6.775 * age)),
            "Woman" => rateResult.Value * (655.1 + (9.563 * weight) + 
                (1.85 * height) - (4.676 * age)),
            _ => 0
        };

        if (target is null)
            return calorieCount;
        if(!Enum.TryParse<TrainingTarget>(target, true, out var trainingTarget))
            return Errors.CaloriesCalculator.IncorrectTrainingTargetType;
        
        var resultCount = trainingTarget switch
        {
            TrainingTarget.ShapeMaintenance => calorieCount,
            TrainingTarget.WeightGain => calorieCount + calorieCount * 0.1,
            TrainingTarget.WeightLoss => calorieCount - calorieCount * 0.1,
            _ => calorieCount
        };

        return resultCount;
    }
    
    public ErrorOr<Nutrients> CalculateDailyNutrientsCount(double dailyCalorieCount, 
        string target)
    {
        if (!Enum.TryParse<TrainingTarget >(target, true, out var trainingTarget))
            return Errors.CaloriesCalculator.IncorrectTrainingTargetType;
        
        return trainingTarget switch
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
            _ => Errors.CaloriesCalculator.IncorrectTrainingTargetType
        };
    }

    private ErrorOr<double> GetPhysicalActivityRate(string rateStr)
    {
        if (!Enum.TryParse(rateStr, out ActivityRate rate))
            return Errors.CaloriesCalculator.IncorrectActivityRateType;
        
        return rate switch
        {
            ActivityRate.None => 1,
            ActivityRate.Low => 1.2,
            ActivityRate.Minimal => 1.375,
            ActivityRate.Middle => 1.55,
            ActivityRate.High => 1.7,
            ActivityRate.Extreme => 1.9,
            _ => throw new ArgumentOutOfRangeException(nameof(rate), "Argument rate is not defined")
        };
    }
}