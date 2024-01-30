using Ardalis.Specification;
using Fitfuel.Workouts.Domain.EquipmentAggregate;

namespace Fitfuel.Workouts.Application.Specifications.Equipments;

public sealed class EquipmentByNameSpec : Specification<Equipment>, ISingleResultSpecification<Equipment>
{
    public EquipmentByNameSpec(string name) =>
        Query.Where(x => x.Name == name);
}