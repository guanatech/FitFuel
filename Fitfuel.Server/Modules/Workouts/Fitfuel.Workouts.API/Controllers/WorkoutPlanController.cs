using Fitfuel.Shared.Presentation;
using Fitfuel.Workouts.Application.Abstractions;
using FitFuel.Workouts.Contracts.WorkoutPlans;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Fitfuel.Workouts.API.Controllers;

[Route("api/v{version:apiVersion}/plans")]
public class WorkoutPlanController : ApiController
{
    private readonly IWorkoutPlanService _workoutPlanService;

    public WorkoutPlanController(IWorkoutPlanService workoutPlanService, IMapper mapper) : base(mapper)
    {
        _workoutPlanService = workoutPlanService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(WorkoutPlanRequest request)
    {
        var workoutPlanResult = await _workoutPlanService.CreateAsync(request);
        return workoutPlanResult.Match(
            value => Ok(value),
            errors => Problem(errors));
    }
    
    [HttpPut]
    public async Task<IActionResult> Update(UpdateWorkoutPlanRequest request)
    {
        var workoutPlanResult = await _workoutPlanService.UpdateAsync(request);
        return workoutPlanResult.Match(
            value => Ok(Mapper.Map<WorkoutPlanResponse>(value)),
            errors => Problem(errors));
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var workoutPlanResult = await _workoutPlanService.DeleteAsync(id);
        return workoutPlanResult.Match(
            value => Ok(value),
            errors => Problem(errors));
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var workoutPlanResult =  await _workoutPlanService.GetByIdAsync(id);
        return workoutPlanResult.Match(
            value => Ok(Mapper.Map<WorkoutPlanResponse>(value)),
            errors => Problem(errors));
    }
    
    [HttpGet("filter")]
    public async Task<IActionResult> Get([FromQuery] WorkoutPlanFilterRequest filter)
    {
        filter = filter ?? new WorkoutPlanFilterRequest();
        var workoutPlans = await _workoutPlanService.GetByFiltersAsync(filter);
        return Ok(workoutPlans);
    }
}