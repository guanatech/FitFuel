using Fitfuel.Shared.Infrastructure.Persistence.Specifications.Filters;
using Fitfuel.Workouts.Domain.ExerciseAggregate.Enums;

namespace Fitfuel.Workouts.Application.Specifications.Exercises;

public class ExerciseFilter : BaseFilter
{
    public string? Name { get; set;}
    public string? Description { get; set;}
    public TimeSpan? Duration { get; set;}
    public ExerciseType? ExerciseType { get; set;}
    public Guid WorkoutId { get; set; }
    public int Repetition { get; set;}
}