using Fitfuel.Workouts.Application.Common.Interfaces;
using Fitfuel.Workouts.Application.Specifications;
using Fitfuel.Workouts.Domain.WorkoutPlanAggregate;

namespace Fitfuel.Workouts.Application.Services;

public class WorkoutPlanService : IWorkoutPlanService
{
    //TODO logger
    
    private readonly IRepository<WorkoutPlan> _repository;
    
    public WorkoutPlanService(IRepository<WorkoutPlan> repository)
    {
        _repository = repository;
    }
    
    //TODO contract validation, exception handle
    public async Task<WorkoutPlan> GetWorkoutPlanAsync(Guid id)
    {
        var workoutPlanSpec = new WorkoutPlanWithItemsSpecification(id);
        
        var workoutPlan = await _repository.FirstOrDefaultAsync(workoutPlanSpec);
        
        return workoutPlan;
    }
}