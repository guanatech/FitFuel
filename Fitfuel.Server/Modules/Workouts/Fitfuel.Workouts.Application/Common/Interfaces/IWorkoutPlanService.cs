using ErrorOr;
using FitFuel.Workouts.Contracts.WorkoutPlans;
using Fitfuel.Workouts.Domain.WorkoutPlanAggregate;

namespace Fitfuel.Workouts.Application.Common.Interfaces;

public interface IWorkoutPlanService
{
    Task<ErrorOr<WorkoutPlan>> GetByIdAsync(Guid workoutPlanId);
    Task<List<WorkoutPlan>> GetByFiltersAsync(WorkoutPlanFilterRequest planFilterRequest);
    Task<ErrorOr<Guid>> CreateAsync(WorkoutPlanRequest request);
    Task<ErrorOr<WorkoutPlan>> UpdateAsync(UpdateWorkoutPlanRequest request);
    Task<ErrorOr<Guid>> DeleteAsync(Guid workoutPlanId);
}
