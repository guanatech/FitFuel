using Fitfuel.Shared.Infrastructure.Persistence.Specifications.Filters;
using Fitfuel.Workouts.Domain.WorkoutPlanAggregate.Enums;

namespace Fitfuel.Workouts.Application.Specifications.WorkoutPlans;

public class WorkoutPlanFilter : BaseFilter
{ 
   public string? Name { get; set; }
   public Level? Level { get; set; }
}