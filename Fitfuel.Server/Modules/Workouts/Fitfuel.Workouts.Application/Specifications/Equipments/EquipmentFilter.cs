using Fitfuel.Shared.Infrastructure.Persistence.Specifications.Filters;

namespace Fitfuel.Workouts.Application.Specifications.Equipments;

public class EquipmentFilter : BaseFilter
{
    public string? Name { get; set; }
}