using Ardalis.Specification;
using Fitfuel.Workouts.Domain.WorkoutPlanAggregate;
using Fitfuel.Workouts.Domain.WorkoutPlanAggregate.ValueObjects;

namespace Fitfuel.Workouts.Application.Specifications;

public sealed class WorkoutPlanWithItemsSpecification :
    Specification<WorkoutPlan>, 
    ISingleResultSpecification<WorkoutPlan>
{
    public WorkoutPlanWithItemsSpecification(WorkoutPlanId id)
    {
        Query
            .Where(w => w.Id == id)
            .Include(w => w.Workouts);
    }
}