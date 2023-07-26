using Fitfuel.Meals.Application.Common.Interfaces;
using Fitfuel.Meals.Contracts.Calories;
using Fitfuel.Meals.Domain.Common.Enums;
using Fitfuel.Meals.Domain.MealAggregate.ValueObjects;
using ErrorOr;
using Fitfuel.Meals.Domain.Common.Errors;

namespace Fitfuel.Meals.Application.Services;

public class CaloriesCalculator : ICaloriesCalculator
{
    public ErrorOr<double> GetDailyCalorieCount(CalculateDailyCaloriesRequest request)
    {
        var rateResult = GetPhysicalActivityRate(request.Rate);
        
        if (rateResult.IsError)
            return rateResult.FirstError;
        
        var calorieCount = request.Gender switch
        {
            "Man" => rateResult.Value * (66.5 + (13.75 * request.Weight) + 
                (5.003 * request.Height) - (6.775 * request.Age)),
            "Woman" => rateResult.Value * (655.1 + (9.563 * request.Weight) + 
                (1.85 * request.Height) - (4.676 * request.Age)),
            _ => 0
        };

        if (request.Target is null)
            return calorieCount;
        var target = (TrainingTarget)Enum.Parse(typeof(TrainingTarget), request.Target);
        
        var resultCount = target switch
        {
            TrainingTarget.ShapeMaintenance => calorieCount,
            TrainingTarget.WeightGain => calorieCount + calorieCount * 0.1,
            TrainingTarget.WeightLoss => calorieCount - calorieCount * 0.1,
            _ => calorieCount
        };

        return resultCount;
    }
    
    public ErrorOr<Nutrients> GetDailyNutrientsCount(CalculateDailyNutrientsRequest request)
    {
        if (!Enum.TryParse(request.TrainingTarget, out TrainingTarget target))
            return Errors.CaloriesCalculator.IncorrectTrainingTargetType;
        
        return target switch
        {
            TrainingTarget.ShapeMaintenance => new Nutrients(proteins: request.DailyCalorieCount*0.2/4, // 20/30/50
                fats: request.DailyCalorieCount*0.3/9, 
                carbs: request.DailyCalorieCount*0.5/4),
            TrainingTarget.WeightGain => new Nutrients(proteins: request.DailyCalorieCount*0.35/4, // 35/20/55
                fats: request.DailyCalorieCount*0.2/9, 
                carbs: request.DailyCalorieCount*0.55/4),
            TrainingTarget.WeightLoss => new Nutrients(proteins: request.DailyCalorieCount*0.25/4, // 25/30/45
                fats: request.DailyCalorieCount*0.3/9, 
                carbs: request.DailyCalorieCount*0.45/4),
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
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}