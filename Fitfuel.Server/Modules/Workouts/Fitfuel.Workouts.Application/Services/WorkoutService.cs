using Fitfuel.Workouts.Application.Specifications.Workouts;
using FitFuel.Workouts.Contracts.Workouts;
using Fitfuel.Workouts.Domain.WorkoutPlanAggregate.Entities;
using MapsterMapper;
using ErrorOr;
using Fitfuel.Workouts.Application.Abstractions;
using Fitfuel.Workouts.Application.Abstractions.Persistence;
using Fitfuel.Workouts.Domain.Common.Errors;

namespace Fitfuel.Workouts.Application.Services;


public class WorkoutService : IWorkoutService
{
    private readonly IRepository<Workout> _workoutRepository;
    private readonly IMapper _mapper;

    public WorkoutService(IRepository<Workout> workoutRepository, IMapper mapper)
    {
        _workoutRepository = workoutRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<Workout>> GetByIdAsync(Guid id)
    {
        if (await _workoutRepository.GetByIdAsync(id) is not { } workout)
            return Errors.Workout.NotFound;

        return workout;
    }

    public async Task<List<Workout>> GetByFiltersAsync(WorkoutFilterRequest filterRequest)
    {
        var spec = new WorkoutSpec(_mapper.Map<WorkoutFilter>(filterRequest));
        var workouts = await _workoutRepository.ListAsync(spec);

        return workouts;
    }

    public async Task<ErrorOr<Guid>> CreateAsync(WorkoutRequest request)
    {
        if (await _workoutRepository.FirstOrDefaultAsync(new WorkoutByNameSpec(request.Name)) is not null)
            return Errors.Workout.DuplicateName;

        var workout = Workout.Create(request.Name, request.WorkoutPlanId,
            request.StartDate, request.Description);

        await _workoutRepository.AddAsync(workout);

        return workout.Id;
    }

    public async Task<ErrorOr<Workout>> UpdateAsync(UpdateWorkoutRequest request)
    {
        if (await _workoutRepository.GetByIdAsync(request.Id) is not { } workout)
            return Errors.Workout.NotFound;

        workout = workout.Update(
            request.Name, 
            request.WorkoutPlanId,
            request.StartDate,
            request.Description);

        await _workoutRepository.UpdateAsync(workout);

        return workout;
    }

    public async Task<ErrorOr<Guid>> DeleteAsync(Guid id)
    {
        if (await _workoutRepository.GetByIdAsync(id) is not { } workout)
            return Errors.Workout.NotFound;

        await _workoutRepository.DeleteAsync(workout);

        return workout.Id;
    }
}