using Fitfuel.Shared.Entities;
using Fitfuel.Workouts.Domain.ExerciseAggregate;

namespace Fitfuel.Workouts.Domain.WorkoutPlanAggregate.Entities;

public class Workout : Entity
{
    private Workout(Guid id, string name, Guid workoutPlanId,
        DateTime startDate, string description) : base(id)
    {
        Name = name;
        WorkoutPlanId = workoutPlanId;
        StartDate = startDate;
        Description = description;
    }
    
    private readonly List<Exercise> _exercises = new();
    
    public string Name { get; private set; }

    public Guid WorkoutPlanId { get; private set; }
    
    public bool IsCompleted { get; private set; }
    
    public DateTime StartDate { get; private set; }
    
    public string Description { get; private set; }

    public IReadOnlyList<Exercise> Exercises => _exercises.AsReadOnly();
    public WorkoutPlan? WorkoutPlan { get; set; }

    public static Workout Create(
        string name, Guid workoutPlanId, DateTime startDate, string description) =>
        new(Guid.NewGuid(), name, workoutPlanId, startDate, description);

    public Workout Update(string name, Guid workoutPlanId, DateTime startDate, string description)
    {
        Name = name;
        WorkoutPlanId = workoutPlanId;
        StartDate = startDate;
        Description = description;

        return this;
    }
    
    public Workout CompleteWorkout()
    {
        IsCompleted = true;
        return this;
    }
    
    public void RemoveExercise(Exercise exercise) =>
        _exercises.Remove(exercise);
    
    public void AddExercise(Exercise exercise) =>
        _exercises.Add(exercise);
}