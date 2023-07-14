using Fitfuel.Workouts.Application.Abstractions;
using FitFuel.Workouts.Contracts.Equipments;
using FitFuel.Workouts.Contracts.Exercises;
using MapsterMapper;

namespace Fitfuel.Workouts.API.Controllers;

using Microsoft.AspNetCore.Mvc;


[Route("api/v{version:apiVersion}/equipments")]
public class EquipmentController : ApiController
{
    private readonly IEquipmentService _equipmentService;
    
    public EquipmentController(IEquipmentService equipmentService, IMapper mapper) : base(mapper)
    {
        _equipmentService = equipmentService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(EquipmentRequest request)
    {
        var equipmentResult = await _equipmentService.CreateAsync(request);
        return equipmentResult.Match(
            value => Ok(value),
            errors => Problem(errors));
    }
    
    [HttpPut]
    public async Task<IActionResult> Update(UpdateEquipmentRequest request)
    {
        var equipmentResult = await _equipmentService.UpdateAsync(request);
        return equipmentResult.Match(
            value => Ok(Mapper.Map<EquipmentResponse>(equipmentResult)),
            errors => Problem(errors));
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var equipmentResult = await _equipmentService.DeleteAsync(id);
        return equipmentResult.Match(
            value => Ok(value),
            errors => Problem(errors));
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var equipmentResult =  await _equipmentService.GetByIdAsync(id);
        return equipmentResult.Match(
            value => Ok(Mapper.Map<EquipmentResponse>(equipmentResult)),
            errors => Problem(errors));
    }
    
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] EquipmentFilterRequest filter)
    {
        filter = filter ?? new EquipmentFilterRequest();
        var equipments = await _equipmentService.GetByFiltersAsync(filter);
        return Ok(Mapper.Map<List<EquipmentResponse>>(equipments));
    }
   
}