using Fitfuel.Workouts.API.Models;
using Fitfuel.Workouts.Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fitfuel.Workouts.API.Controllers;

[Route("api/v{version:apiVersion}/plans")]
public class WorkoutPlanController : ApiController
{
    private readonly IWorkoutPlanService _service;

    public WorkoutPlanController(IWorkoutPlanService service)
    {
        _service = service;
    }
    
    
    [HttpGet("{id:guid}")]
    public async Task<WorkoutPlanDto> Get(Guid id)
    {
        var workoutPlan =  await _service.GetWorkoutPlanAsync(id);
        return new WorkoutPlanDto(workoutPlan.Id);
    }
    
    
    // Example of using filter dto 
    /*[HttpGet]
    public Task<List<WorkoutPlanDto>> Get([FromQuery] WorkoutPlanFilterDto filter)
    {
        filter = filter ?? new WorkoutPlanFilterDto();

        // Here you can decide if you want the collections as well

        filter.LoadChildren = true;
        filter.IsPagingEnabled = true;

        return _service.GetWorkoutPlanAsync(filter);
    }*/
}