using Fitfuel.Meals.Application.Common.Interfaces;
using Fitfuel.Meals.Contracts.Calories;
using Microsoft.AspNetCore.Mvc;

namespace Fitfuel.Meals.API.Controllers;

[Route("calculator")]
public class CaloriesController : Controller
{
    private readonly ICaloriesCalculator _caloriesCalculator;

    public CaloriesController(ICaloriesCalculator caloriesCalculator)
    {
        _caloriesCalculator = caloriesCalculator;
    }
    
    public IActionResult CalculateDailyCount(CalculateDailyCaloriesRequest request)
    {
        var result = _caloriesCalculator.GetDailyCalorieCount(request);
        return result.Match(
            dailyCount => Ok(dailyCount),
            errors => Problem());
    }
    
    public IActionResult CalculateDailyNutrients(CalculateDailyCaloriesRequest request)
    {
        var result = _caloriesCalculator.GetDailyCalorieCount(request);
        return result.Match(
            nutrients => Ok(nutrients),
            errors => Problem());
    }
}