using Fitfuel.Shared.Infrastructure.Persistence.Specifications.Filters;

namespace FitFuel.Workouts.Contracts.Workouts;

public class WorkoutFilterRequest : BaseFilter
{
    public string Name { get; init; }

    public bool IsCompleted { get; init; }
}