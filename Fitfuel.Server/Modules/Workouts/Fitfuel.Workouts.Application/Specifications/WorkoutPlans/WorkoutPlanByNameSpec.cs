using Ardalis.Specification;
using Fitfuel.Workouts.Domain.WorkoutPlanAggregate;

namespace Fitfuel.Workouts.Application.Specifications.WorkoutPlans;

public sealed class WorkoutPlanByNameSpec :
    Specification<WorkoutPlan>,
    ISingleResultSpecification<WorkoutPlan>
{

    public WorkoutPlanByNameSpec(string name) =>
        Query.Where(b => b.Name == name);

}