using Fitfuel.Shared.Entities;
using Fitfuel.Workouts.Domain.WorkoutPlanAggregate.ValueObjects;

namespace Fitfuel.Workouts.Domain.WorkoutPlanAggregate.Entities;

public class Workout : Entity<WorkoutId>
{
    private Workout(WorkoutId id, string name, WorkoutPlanId workoutPlanId, DateTime duration, 
        DateTime startDate, string description) : base(id)
    {
        Name = name;
        WorkoutPlanId = workoutPlanId;
        Duration = duration;
        StartDate = startDate;
        Description = description;
    }
    
    public string Name { get; private set; }

    public WorkoutPlanId WorkoutPlanId { get; init; }
    
    public DateTime Duration { get; private set; }
    
    public DateTime StartDate { get; init; }
    
    public string Description { get; private set; }

    public WorkoutPlan? WorkoutPlan { get; set; }

    public static Workout Create(
        string name, WorkoutPlanId workoutPlanId, DateTime duration, 
        DateTime startDate, string description) =>
        new(WorkoutId.CreateUnique(), name, workoutPlanId, duration, startDate, description);
}