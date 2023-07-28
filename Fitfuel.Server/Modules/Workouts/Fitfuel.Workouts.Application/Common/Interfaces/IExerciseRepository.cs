using ErrorOr;
using FitFuel.Workouts.Contracts.Exercises;
using Fitfuel.Workouts.Domain.ExerciseAggregate;

namespace Fitfuel.Workouts.Application.Common.Interfaces;

public interface IExerciseService
{
    Task<ErrorOr<Exercise>> GetByIdAsync(Guid exerciseId);
    Task<List<Exercise>> GetByFiltersAsync(ExerciseFilterRequest filterRequest);
    Task<ErrorOr<Guid>> CreateAsync(ExerciseRequest request);
    Task<ErrorOr<Exercise>> UpdateAsync(UpdateExerciseRequest request);
    Task<ErrorOr<Guid>> DeleteAsync(Guid workoutPlanId);
}