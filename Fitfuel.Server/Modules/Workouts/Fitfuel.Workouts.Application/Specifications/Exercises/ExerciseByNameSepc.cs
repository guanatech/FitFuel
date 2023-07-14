using Ardalis.Specification;
using Fitfuel.Workouts.Domain.ExerciseAggregate;

namespace Fitfuel.Workouts.Application.Specifications.Exercises;

public sealed class ExerciseByNameSpec : 
    Specification<Exercise>,
    ISingleResultSpecification<Exercise>
{
    public ExerciseByNameSpec(string name) =>
        Query.Where(x => x.Name == name);
}