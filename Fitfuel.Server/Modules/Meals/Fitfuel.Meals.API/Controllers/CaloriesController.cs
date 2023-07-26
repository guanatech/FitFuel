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
    
   [HttpGet("calories")]
   public IActionResult CalculateDailyCount([FromQuery]CalculateDailyCaloriesRequest request)
    {
        var result = _caloriesCalculator.GetDailyCaloriesCount(request);
        return result.Match(
            dailyCount => Ok(dailyCount),
            errors => Problem());
    }
    
   [HttpGet("nutrients")] 
   public IActionResult CalculateDailyNutrients([FromQuery]CalculateDailyNutrientsRequest request)
    {
        var result = _caloriesCalculator.GetDailyNutrientsCount(request);
        return result.Match(
            nutrients => Ok(nutrients),
            errors => Problem());
    }
}