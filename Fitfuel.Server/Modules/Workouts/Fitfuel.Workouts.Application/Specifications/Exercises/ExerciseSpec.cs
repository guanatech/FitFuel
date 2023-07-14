using Ardalis.Specification;
using Fitfuel.Shared.Infrastructure.Persistence.Specifications.Helpers;
using Fitfuel.Workouts.Domain.ExerciseAggregate;

namespace Fitfuel.Workouts.Application.Specifications.Exercises;

public sealed class ExerciseSpec : Specification<Exercise>
{
    public ExerciseSpec(ExerciseFilter filter)
    {
        Query.OrderBy(x => x.Name)
            .ThenByDescending(x => x.Duration);

        if (filter.LoadChildren)
            Query.Include(x => x.Workout);

        if (filter.IsPagingEnabled)
            Query.Skip(PaginationHelper.CalculateSkip(filter))
                .Take(PaginationHelper.CalculateTake(filter));
        
        if (!string.IsNullOrEmpty(filter.Name))
            Query.Where(x => x.Name == filter.Name);

        if (!string.IsNullOrEmpty(filter.Description))
            Query.Where(x => x.Description == filter.Description);

        if (filter.WorkoutId != Guid.Empty)
            Query.Where(x => x.WorkoutId == filter.WorkoutId);

        /*
        if (filter.ExerciseType is not null)
            Query.Where(x => x.ExerciseType == filter.ExerciseType);
        
        if (filter.Duration != TimeSpan.Zero)
            Query.Where(x => x.Duration == filter.Duration);
            */
        
        if (filter.Repetition != 0)
            Query.Where(x => x.Repetition == filter.Repetition);
        
    }
}