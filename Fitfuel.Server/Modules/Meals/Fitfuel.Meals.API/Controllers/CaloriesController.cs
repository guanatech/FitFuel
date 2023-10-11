using Fitfuel.Meals.Application.Common.Interfaces;
using Fitfuel.Meals.Contracts.Calories;
using Fitfuel.Shared.Presentation;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Fitfuel.Meals.API.Controllers;

[Route("calculator")]
public class CaloriesController : ApiController
{
    private readonly ICaloriesService _caloriesService;
    
    protected CaloriesController(IMapper mapper, ICaloriesService caloriesService) : base(mapper)
    {
        _caloriesService = caloriesService;
    }
    
   [HttpGet("calories")]
   public IActionResult CalculateDailyCount([FromQuery]GetDailyCaloriesRequest request)
    {
        var result = _caloriesService.GetDailyCaloriesCount(request);
        return result.Match(
            dailyCount => Ok(dailyCount),
            errors => Problem(errors));
    }
    
   [HttpGet("nutrients")] 
   public IActionResult CalculateDailyNutrients([FromQuery]GetDailyNutrientsRequest request)
    {
        var result = _caloriesService.GetDailyNutrientsCount(request);
        return result.Match(
            nutrients => Ok(nutrients),
            errors => Problem(errors));
    }
}