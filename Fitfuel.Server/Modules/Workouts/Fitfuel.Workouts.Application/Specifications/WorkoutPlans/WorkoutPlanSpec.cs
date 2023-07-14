using Ardalis.Specification;
using Fitfuel.Shared.Infrastructure.Persistence.Specifications.Helpers;
using Fitfuel.Workouts.Domain.WorkoutPlanAggregate;

namespace Fitfuel.Workouts.Application.Specifications.WorkoutPlans;

public sealed class WorkoutPlanSpec : Specification<WorkoutPlan>
{
    public WorkoutPlanSpec(WorkoutPlanFilter filter)
    {
        Query.OrderBy(x => x.Name)
            .ThenByDescending(x => x.Level);

        if (filter.LoadChildren)
            Query.Include(x => x.Workouts);

        if (filter.IsPagingEnabled)
            Query.Skip(PaginationHelper.CalculateSkip(filter))
                .Take(PaginationHelper.CalculateTake(filter));
        
        if (!string.IsNullOrEmpty(filter.Name))
            Query.Where(x => x.Name == filter.Name);
        
        if (filter.Level is not null)
            Query.Where(x => x.Level == filter.Level);
    }
}