using Fitfuel.Shared.Entities;
using Fitfuel.Workouts.Domain.ExerciseAggregate.ValueObjects;
using Fitfuel.Workouts.Domain.WorkoutAggregate;
using Fitfuel.Workouts.Domain.WorkoutAggregate.ValueObjects;

namespace Fitfuel.Workouts.Domain.ExerciseAggregate;

public class Exercise : AggregateRoot<ExerciseId>
{
    protected Exercise(
        ExerciseId id, 
        string name,
        string description, 
        DateTime duration, 
        ExerciseType exerciseType, 
        int repetition) 
        : base(id)
    {
        Name = name;
        Description = description;
        Duration = duration;
        ExerciseType = exerciseType;
        Repetition = repetition;
    }
    

    
    public string Name { get; private set; }

    public string Description { get; private set; }
    
    public DateTime Duration { get; private set; }
    
    public ExerciseType ExerciseType { get; private set; }
    
    public int Repetition { get; private set; }
    
    public WorkoutId WorkoutId { get; private set; }
    
    public Workout Workout { get; set; }

    public static Exercise Create(
        string name, 
        string description, 
        DateTime duration, 
        ExerciseType exerciseType, int repetition) =>
        new Exercise(ExerciseId.CreateUnique(), name, description, duration, exerciseType, repetition);
}