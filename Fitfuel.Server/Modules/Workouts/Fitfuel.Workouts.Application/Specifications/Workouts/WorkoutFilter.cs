using Fitfuel.Shared.Infrastructure.Persistence.Specifications.Filters;

namespace Fitfuel.Workouts.Application.Specifications.Workouts;

public class WorkoutFilter : BaseFilter
{
    public string? Name { get; init; }
    public bool IsCompleted { get; init; }
    
}