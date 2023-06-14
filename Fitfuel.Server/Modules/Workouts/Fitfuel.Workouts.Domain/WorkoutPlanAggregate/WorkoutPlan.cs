using Fitfuel.Shared.Entities;
using Fitfuel.Workouts.Domain.WorkoutPlanAggregate.Entities;
using Fitfuel.Workouts.Domain.WorkoutPlanAggregate.Enums;
using Fitfuel.Workouts.Domain.WorkoutPlanAggregate.ValueObjects;

namespace Fitfuel.Workouts.Domain.WorkoutPlanAggregate;

public class WorkoutPlan : AggregateRoot<WorkoutPlanId>
{
    private WorkoutPlan(WorkoutPlanId id, string name, Level level) : base(id)
    {
        Name = name;
        Level = level;
    }

    private readonly List<Workout> _workouts = new();
    
    public string Name { get; private set; }

    public Level Level { get; private set; }
    
    public IReadOnlyList<Workout> Workouts => _workouts;

    public static WorkoutPlan Create(string name, Level level) => new(WorkoutPlanId.CreateUnique(), name, level);

    public void AddWorkout(Workout workout) => _workouts.Add(workout);
}