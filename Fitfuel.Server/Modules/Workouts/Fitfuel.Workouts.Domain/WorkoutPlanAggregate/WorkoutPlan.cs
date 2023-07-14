using Fitfuel.Shared.Entities;
using Fitfuel.Workouts.Domain.WorkoutPlanAggregate.Entities;
using Fitfuel.Workouts.Domain.WorkoutPlanAggregate.Enums;

namespace Fitfuel.Workouts.Domain.WorkoutPlanAggregate;

public class WorkoutPlan : AggregateRoot
{
    private WorkoutPlan(Guid id, string name, Level level) : base(id)
    {
        Name = name;
        Level = level;
    }

    private readonly List<Workout> _workouts = new();

    public string Name { get; private set; }

    public Level Level { get; private set; }

    public IReadOnlyList<Workout> Workouts => _workouts;

    public static WorkoutPlan Create(string name, Level level) => new(Guid.NewGuid(), name, level);

    public WorkoutPlan Update(string name, Level level)
    {
        Name = name;
        Level = level;

        return this;
    }

    public void RemoveWorkout(Workout workout) =>
        _workouts.Remove(workout);
    
    public void AddWorkout(Workout workout) =>
        _workouts.Add(workout);
}