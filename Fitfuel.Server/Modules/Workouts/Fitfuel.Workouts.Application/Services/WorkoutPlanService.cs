using Fitfuel.Workouts.Domain.WorkoutPlanAggregate;
using ErrorOr;
using Fitfuel.Shared.Infrastructure.Abstractions;
using Fitfuel.Workouts.Application.Common.Interfaces;
using Fitfuel.Workouts.Application.Specifications.WorkoutPlans;
using FitFuel.Workouts.Contracts.WorkoutPlans;
using Fitfuel.Workouts.Domain.Common.Errors;
using MapsterMapper;

namespace Fitfuel.Workouts.Application.Services;

public class WorkoutPlanService : IWorkoutPlanService
{
    
    private readonly IRepository<WorkoutPlan> _workoutPlanRepository;
    private readonly IMapper _mapper;
    
    public WorkoutPlanService(IRepository<WorkoutPlan> workoutPlanRepository, IMapper mapper)
    {
        _workoutPlanRepository = workoutPlanRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<WorkoutPlan>> GetByIdAsync(Guid workoutPlanId)
    {
        if (await _workoutPlanRepository.GetByIdAsync(workoutPlanId) is not { } workoutPlan)
            return Errors.WorkoutPlan.NotFound;

        return workoutPlan;
    }

    public async Task<List<WorkoutPlan>> GetByFiltersAsync(WorkoutPlanFilterRequest planFilterRequest)
    {
        var spec = new WorkoutPlanSpec(_mapper.Map<WorkoutPlanFilter>(planFilterRequest));
        var workoutPlans = await _workoutPlanRepository.ListAsync(spec);


        return workoutPlans;
    }

    public async Task<ErrorOr<Guid>> CreateAsync(WorkoutPlanRequest request)
    {
        if (await _workoutPlanRepository.FirstOrDefaultAsync(new WorkoutPlanByNameSpec(request.Name)) is not null)
            return Errors.WorkoutPlan.DuplicateName;

        var workoutPlan = WorkoutPlan.Create(request.Name, request.Level);

        await _workoutPlanRepository.AddAsync(workoutPlan);

        return workoutPlan.Id;
    }
    
    public async Task<ErrorOr<WorkoutPlan>> UpdateAsync(UpdateWorkoutPlanRequest request)
    {
        if (await _workoutPlanRepository.GetByIdAsync(request.Id) is not { } workoutPlan)
            return Errors.WorkoutPlan.NotFound;

        workoutPlan.Update(request.Name, request.Level);

        await _workoutPlanRepository.UpdateAsync(workoutPlan);

        return workoutPlan;

    }

    public async Task<ErrorOr<Guid>> DeleteAsync(Guid workoutPlanId)
    {
        if (await _workoutPlanRepository.GetByIdAsync(workoutPlanId) is not { } workoutPlan)
            return Errors.WorkoutPlan.NotFound;

        await _workoutPlanRepository.DeleteAsync(workoutPlan);

        return workoutPlan.Id;
    }
}