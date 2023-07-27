using Fitfuel.Shared.Presentation;
using Fitfuel.Workouts.Application.Abstractions;
using FitFuel.Workouts.Contracts.Workouts;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Fitfuel.Workouts.API.Controllers;

[Route("api/v{version:apiVersion}/workouts")]
public class WorkoutController : ApiController
{
    private readonly IWorkoutService _workoutService;

    public WorkoutController(IWorkoutService workoutService, IMapper mapper) : base(mapper)
    {
        _workoutService = workoutService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(WorkoutRequest response)
    {
        var workoutResult = await _workoutService.CreateAsync(response);
        return workoutResult.Match(
            value => Ok(value),
            errors => Problem(errors));
    }
    
    [HttpPut]
    public async Task<IActionResult> Update(UpdateWorkoutRequest response)
    {
        var workoutResult = await _workoutService.UpdateAsync(response);
        return workoutResult.Match(
            value => Ok(Mapper.Map<WorkoutResponse>(workoutResult)),
            errors => Problem(errors));
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var workoutResult = await _workoutService.DeleteAsync(id);
        return workoutResult.Match(
            value => Ok(value),
            errors => Problem(errors));
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var workoutResult =  await _workoutService.GetByIdAsync(id);
        return workoutResult.Match(
            value => Ok(Mapper.Map<WorkoutResponse>(workoutResult)),
            errors => Problem(errors));
    }
    
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] WorkoutFilterRequest filter)
    {
        filter = filter ?? new WorkoutFilterRequest();
        var workouts = await _workoutService.GetByFiltersAsync(filter);
        return Ok(Mapper.Map<List<WorkoutResponse>>(workouts));
    }

}