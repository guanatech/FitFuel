using Fitfuel.Workouts.Domain.WorkoutPlanAggregate;
using Fitfuel.Workouts.Domain.WorkoutPlanAggregate.ValueObjects;

namespace Fitfuel.Workouts.Application.Interfaces;

public interface IWorkoutPlanService
{
    Task<WorkoutPlan> GetWorkoutPlanAsync(Guid id);
}