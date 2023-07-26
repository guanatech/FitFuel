using Fitfuel.Workouts.Application.Abstractions;
using Fitfuel.Workouts.Domain.Common.Errors;
using Fitfuel.Workouts.Domain.EquipmentAggregate;
using MapsterMapper;
using ErrorOr;
using Fitfuel.Workouts.Application.Abstractions.Persistence;
using Fitfuel.Workouts.Application.Specifications.Equipments;
using FitFuel.Workouts.Contracts.Equipments;

namespace Fitfuel.Workouts.Application.Services;


public class EquipmentService : IEquipmentService
{
    private readonly IRepository<Equipment> _equipmentRepository;
    private readonly IMapper _mapper;

    public EquipmentService(IRepository<Equipment> equipmentRepository, IMapper mapper)
    {
        _equipmentRepository = equipmentRepository;
        _mapper = mapper;
    }
    
    
    public async Task<ErrorOr<Equipment>> GetByIdAsync(Guid equipmentId)
    {
        if (await _equipmentRepository.GetByIdAsync(equipmentId) is not { } equipment)
            return Errors.Exercise.NotFound;

        return equipment;
    }

    public async Task<List<Equipment>> GetByFiltersAsync(EquipmentFilterRequest filterRequest)
    {
        var spec = new EquipmentSpec(_mapper.Map<EquipmentFilter>(filterRequest));
        var equipments = await _equipmentRepository.ListAsync(spec);

        return equipments;
    }

    public async Task<ErrorOr<Guid>> CreateAsync(EquipmentRequest request)
    {
        if (await _equipmentRepository.FirstOrDefaultAsync(new EquipmentByNameSpec(request.Name)) is not null)
            return Errors.WorkoutPlan.DuplicateName;

        var equipment = Equipment.Create(request.Name);

        await _equipmentRepository.AddAsync(equipment);

        return equipment.Id;
    }
    
    public async Task<ErrorOr<Equipment>> UpdateAsync(UpdateEquipmentRequest request)
    {
        if (await _equipmentRepository.GetByIdAsync(request.Id) is not { } equipment)
            return Errors.WorkoutPlan.NotFound;

        equipment.Update(request.Name);

        await _equipmentRepository.UpdateAsync(equipment);

        return equipment;

    }

    public async Task<ErrorOr<Guid>> DeleteAsync(Guid workoutPlanId)
    {
        if (await _equipmentRepository.GetByIdAsync(workoutPlanId) is not { } workoutPlan)
            return Errors.WorkoutPlan.NotFound;

        await _equipmentRepository.DeleteAsync(workoutPlan);

        return workoutPlan.Id;
    }
}