using Ardalis.Specification;
using Fitfuel.Shared.Infrastructure.Persistence.Specifications.Helpers;
using Fitfuel.Workouts.Domain.WorkoutPlanAggregate.Entities;

namespace Fitfuel.Workouts.Application.Specifications.Workouts;

public sealed class WorkoutSpec : Specification<Workout>
{
    public WorkoutSpec(WorkoutFilter filter)
    {
        Query.OrderBy(x => x.Name)
            .ThenByDescending(x => x.WorkoutPlanId);

        if (filter.LoadChildren)
            Query.Include(x => x.Exercises);

        if (filter.IsPagingEnabled)
            Query.Skip(PaginationHelper.CalculateSkip(filter))
                .Take(PaginationHelper.CalculateTake(filter));
        
        if (!string.IsNullOrEmpty(filter.Name))
            Query.Where(x => x.Name == filter.Name);
        
        if (filter.IsCompleted)
            Query.Where(x => x.IsCompleted == filter.IsCompleted);
    }
    
    
}