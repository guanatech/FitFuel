using Fitfuel.Meals.Application.Common.Interfaces;
using Fitfuel.Meals.Contracts.MealSchedules;
using Microsoft.AspNetCore.Mvc;

namespace Fitfuel.Meals.API.Controllers;

[Route("mealSchedule")]
public class MealSchedulesController : Controller
{
    private readonly IMealSchedulesService _mealSchedulesService;

    public MealSchedulesController(IMealSchedulesService mealSchedulesService)
    {
        _mealSchedulesService = mealSchedulesService;
    }

    public async Task<IActionResult> Get(Guid profileId)
    {
        var result = await _mealSchedulesService.GetMealScheduleAsync(profileId);
        return result.Match(
            schedule => Ok(schedule),
            errors => Problem());
    }
    
    public async Task<IActionResult> Create(CreateMealScheduleRequest request)
    {
        var result = await _mealSchedulesService.SetMealScheduleAsync(request);
        return result.Match(
            schedule => Ok(schedule),
            errors => Problem());
    }
    
    public async Task<IActionResult> Update(UpdateMealScheduleRequest request)
    {
        var result = await _mealSchedulesService.UpdateMealScheduleAsync(request);
        return result.Match(
            schedule => Ok(schedule),
            errors => Problem());
    }
}