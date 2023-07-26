using Fitfuel.Workouts.Application.Abstractions;
using Fitfuel.Workouts.Application.Specifications.Exercises;
using Fitfuel.Workouts.Domain.ExerciseAggregate;
using MapsterMapper;
using ErrorOr;
using Fitfuel.Shared.Infrastructure.Abstractions;
using FitFuel.Workouts.Contracts.Exercises;
using Fitfuel.Workouts.Domain.Common.Errors;

namespace Fitfuel.Workouts.Application.Services;


public class ExerciseService : IExerciseService
{
    private readonly IRepository<Exercise> _exerciseRepository;
    private readonly IMapper _mapper;
    
    public ExerciseService(IRepository<Exercise> exerciseRepository, IMapper mapper)
    {
        _exerciseRepository = exerciseRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<Exercise>> GetByIdAsync(Guid exerciseId)
    {
        if (await _exerciseRepository.GetByIdAsync(exerciseId) is not { } exercise)
            return Errors.Exercise.NotFound;

        return exercise;
    }

    public async Task<List<Exercise>> GetByFiltersAsync(ExerciseFilterRequest filterRequest)
    {
        var spec = new ExerciseSpec(_mapper.Map<ExerciseFilter>(filterRequest));
        var exercises = await _exerciseRepository.ListAsync(spec);

        return exercises;
    }

    public async Task<ErrorOr<Guid>> CreateAsync(ExerciseRequest request)
    {
        if (await _exerciseRepository.FirstOrDefaultAsync(new ExerciseByNameSpec(request.Name)) is not null)
            return Errors.Exercise.DuplicateName;

        var exercise = Exercise.Create(
            request.WorkoutId, 
            request.EquipmentId,
            request.Name,
            request.Description,
            request.Duration,
            request.ExerciseType,
            request.Repetition);

        await _exerciseRepository.AddAsync(exercise);

        return exercise.Id;
    }
    
    public async Task<ErrorOr<Exercise>> UpdateAsync(UpdateExerciseRequest request)
    {
        if (await _exerciseRepository.GetByIdAsync(request.Id) is not { } exercise)
            return Errors.Exercise.NotFound;

        exercise.Update(
            request.WorkoutId,
            request.EquipmentId,
            request.Name,
            request.Description,
            request.Duration,
            request.ExerciseType,
            request.Repetition);

        await _exerciseRepository.UpdateAsync(exercise);

        return exercise;

    }

    public async Task<ErrorOr<Guid>> DeleteAsync(Guid workoutPlanId)
    {
        if (await _exerciseRepository.GetByIdAsync(workoutPlanId) is not { } workoutPlan)
            return Errors.Exercise.NotFound;

        await _exerciseRepository.DeleteAsync(workoutPlan);

        return workoutPlan.Id;
    }
}