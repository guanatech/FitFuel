using ErrorOr;
using FitFuel.Workouts.Contracts.Equipments;
using Fitfuel.Workouts.Domain.EquipmentAggregate;

namespace Fitfuel.Workouts.Application.Abstractions;

public interface IEquipmentService
{
    Task<ErrorOr<Equipment>> GetByIdAsync(Guid equipmentId);
    Task<List<Equipment>> GetByFiltersAsync(EquipmentFilterRequest filterRequest);
    Task<ErrorOr<Guid>> CreateAsync(EquipmentRequest request);
    Task<ErrorOr<Equipment>> UpdateAsync(UpdateEquipmentRequest request);
    Task<ErrorOr<Guid>> DeleteAsync(Guid workoutPlanId);
}
