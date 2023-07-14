using Ardalis.Specification;
using Fitfuel.Workouts.Domain.WorkoutPlanAggregate.Entities;

namespace Fitfuel.Workouts.Application.Specifications.Workouts;

public sealed class WorkoutByNameSpec :
    Specification<Workout>,
    ISingleResultSpecification<Workout>
{

    public WorkoutByNameSpec(string name) =>
        Query.Where(b => b.Name == name);

}