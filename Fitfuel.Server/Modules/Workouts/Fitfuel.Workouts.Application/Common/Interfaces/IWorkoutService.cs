using ErrorOr;
using FitFuel.Workouts.Contracts.Workouts;
using Fitfuel.Workouts.Domain.WorkoutPlanAggregate.Entities;

namespace Fitfuel.Workouts.Application.Common.Interfaces;

public interface IWorkoutService
{
    Task<ErrorOr<Workout>> GetByIdAsync(Guid id);
    Task<List<Workout>> GetByFiltersAsync(WorkoutFilterRequest filterRequest);
    Task<ErrorOr<Guid>> CreateAsync(WorkoutRequest request);
    Task<ErrorOr<Workout>> UpdateAsync(UpdateWorkoutRequest request);
    Task<ErrorOr<Guid>> DeleteAsync(Guid id);
}