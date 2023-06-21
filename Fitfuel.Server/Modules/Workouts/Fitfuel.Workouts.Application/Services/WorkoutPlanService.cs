using Fitfuel.Shared.Persistence.Interfaces;
using Fitfuel.Workouts.Application.Specifications;
using Fitfuel.Workouts.Domain.WorkoutPlanAggregate;
using Fitfuel.Workouts.Domain.WorkoutPlanAggregate.ValueObjects;

namespace Fitfuel.Workouts.Application.Services;

public class WorkoutPlanService 
{
    //TODO logger
    
    private readonly IReadRepository<WorkoutPlan> _repository;
    
    public WorkoutPlanService(IReadRepository<WorkoutPlan> repository)
    {
        _repository = repository;
    }
    
    //TODO contract validation, exception handle
    public async Task<WorkoutPlan> GetWorkoutPlanAsync(Guid id)
    {
        var workoutPlanSpec = new WorkoutPlanWithItemsSpecification(new WorkoutPlanId(id));
        
        var workoutPlan = await _repository.FirstOrDefaultAsync(workoutPlanSpec);

        return workoutPlan;
    }
}