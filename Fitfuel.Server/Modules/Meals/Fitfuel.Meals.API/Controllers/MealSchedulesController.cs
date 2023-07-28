using Fitfuel.Meals.Application.Common.Interfaces;
using Fitfuel.Meals.Contracts.MealSchedules;
using Fitfuel.Shared.Presentation;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Fitfuel.Meals.API.Controllers;

[Route("mealSchedule")]
public class MealSchedulesController : ApiController
{
    private readonly IMealSchedulesService _mealSchedulesService;

    public MealSchedulesController(IMapper mapper, IMealSchedulesService mealSchedulesService) : base(mapper)
    {
        _mealSchedulesService = mealSchedulesService;
    }

    public async Task<IActionResult> Get(Guid profileId)
    {
        var result = await _mealSchedulesService.GetMealScheduleAsync(profileId);
        return result.Match(
            schedule => Ok(schedule),
            errors => Problem(errors));
    }
    
    public async Task<IActionResult> Create(CreateMealScheduleRequest request)
    {
        var result = await _mealSchedulesService.SetMealScheduleAsync(request);
        return result.Match(
            schedule => Ok(schedule),
            errors => Problem(errors));
    }
    
    public async Task<IActionResult> Update(UpdateMealScheduleRequest request)
    {
        var result = await _mealSchedulesService.UpdateMealScheduleAsync(request);
        return result.Match(
            schedule => Ok(schedule),
            errors => Problem(errors));
    }
}