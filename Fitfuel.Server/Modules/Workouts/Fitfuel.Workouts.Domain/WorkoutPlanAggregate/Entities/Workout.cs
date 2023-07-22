using Fitfuel.Shared.Entities;

namespace Fitfuel.Workouts.Domain.WorkoutPlanAggregate.Entities;

public class Workout : Entity
{
    private Workout(Guid id, string name, Guid workoutPlanId, DateTime duration, 
        DateTime startDate, string description) : base(id)
    {
        Name = name;
        WorkoutPlanId = workoutPlanId;
        Duration = duration;
        StartDate = startDate;
        Description = description;
    }
    
    public string Name { get; private set; }

    public Guid WorkoutPlanId { get; init; }
    
    public DateTime Duration { get; private set; }
    
    public DateTime StartDate { get; init; }
    
    public string Description { get; private set; }

    public WorkoutPlan? WorkoutPlan { get; set; }

    public static Workout Create(
        string name, Guid workoutPlanId, DateTime duration, 
        DateTime startDate, string description) =>
        new(Guid.NewGuid(), name, workoutPlanId, duration, startDate, description);
}