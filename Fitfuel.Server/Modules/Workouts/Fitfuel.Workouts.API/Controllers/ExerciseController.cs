using Fitfuel.Shared.Presentation;
using Fitfuel.Workouts.Application.Abstractions;
using FitFuel.Workouts.Contracts.Exercises;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Fitfuel.Workouts.API.Controllers;


[Route("api/v{version:apiVersion}/exercises")]
public class ExerciseController : ApiController
{
    private readonly IExerciseService _exerciseService;

    public ExerciseController(IExerciseService exerciseService, IMapper mapper) : base(mapper)
    {
        _exerciseService = exerciseService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(ExerciseRequest request)
    {
        var exerciseResult = await _exerciseService.CreateAsync(request);
        return exerciseResult.Match(
            value => Ok(value),
            errors => Problem(errors));
    }
    
    [HttpPut]
    public async Task<IActionResult> Update(UpdateExerciseRequest request)
    {
        var exerciseResult = await _exerciseService.UpdateAsync(request);
        return exerciseResult.Match(
            value => Ok(Mapper.Map<ExerciseResponse>(value)),
            errors => Problem(errors));
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var exerciseResult = await _exerciseService.DeleteAsync(id);
        return exerciseResult.Match(
            value => Ok(value),
            errors => Problem(errors));
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var exerciseResult =  await _exerciseService.GetByIdAsync(id);
        return exerciseResult.Match(
            value => Ok(Mapper.Map<ExerciseResponse>(value)),
            errors => Problem(errors));
    }
    
    [HttpGet("filter")]
    public async Task<IActionResult> Get([FromQuery] ExerciseFilterRequest filter)
    {
        filter = filter ?? new ExerciseFilterRequest();
        var exercises = await _exerciseService.GetByFiltersAsync(filter);
        return Ok(Mapper.Map<List<ExerciseResponse>>(exercises));
    }

}