using Fitfuel.Shared.Infrastructure.Persistence.Specifications.Filters;

namespace FitFuel.Workouts.Contracts.Equipments;

public class EquipmentFilterRequest : BaseFilter
{
    public string Name { get; init; }
}