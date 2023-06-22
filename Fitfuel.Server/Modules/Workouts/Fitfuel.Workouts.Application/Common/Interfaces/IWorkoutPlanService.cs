using Fitfuel.Workouts.Domain.WorkoutPlanAggregate;

namespace Fitfuel.Workouts.Application.Common.Interfaces;

public interface IWorkoutPlanService
{
    Task<WorkoutPlan> GetWorkoutPlanAsync(Guid id);
}