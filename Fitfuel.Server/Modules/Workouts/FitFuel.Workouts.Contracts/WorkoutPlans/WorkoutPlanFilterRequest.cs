using Fitfuel.Shared.Infrastructure.Persistence.Specifications.Filters;
using Fitfuel.Workouts.Domain.WorkoutPlanAggregate.Enums;

namespace FitFuel.Workouts.Contracts.WorkoutPlans;

public class WorkoutPlanFilterRequest : BaseFilter
{
    public string? Name { get; set; }
    
    public Level Level { get; set; }
}