using Ardalis.Specification;
using Fitfuel.Workouts.Domain.WorkoutPlanAggregate;

namespace Fitfuel.Workouts.Application.Specifications;

public sealed class WorkoutPlanWithItemsSpecification :
    Specification<WorkoutPlan>, 
    ISingleResultSpecification<WorkoutPlan>
{
    public WorkoutPlanWithItemsSpecification(Guid id)
    {
        Query
            .Where(w => w.Id == id)
            .Include(w => w.Workouts);
    }
}