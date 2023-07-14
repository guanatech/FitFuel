using Ardalis.Specification;
using Fitfuel.Shared.Infrastructure.Persistence.Specifications.Helpers;
using Fitfuel.Workouts.Domain.EquipmentAggregate;

namespace Fitfuel.Workouts.Application.Specifications.Equipments;

public sealed class EquipmentSpec : Specification<Equipment>
{
    public EquipmentSpec(EquipmentFilter filter)
    {
        Query.OrderBy(x => x.Name);
        
        if (filter.LoadChildren)
            Query.Include(x => x.Exercises);

        if (filter.IsPagingEnabled)
            Query.Skip(PaginationHelper.CalculateSkip(filter))
                .Take(PaginationHelper.CalculateTake(filter));
        
        if (!string.IsNullOrEmpty(filter.Name))
            Query.Where(x => x.Name == filter.Name);

        
    }
}