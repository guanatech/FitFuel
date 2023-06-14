using Fitfuel.Shared.Entities;
using Fitfuel.Workouts.Domain.ExerciseAggregate;
using Fitfuel.Workouts.Domain.WorkoutAggregate.ValueObjects;

namespace Fitfuel.Workouts.Domain.WorkoutAggregate;

public class Workout : AggregateRoot<WorkoutId>
{
    public Workout(
        WorkoutId id,
        string name, 
        DateTime duration, 
        DateTime startDate, 
        string description) 
        : base(id)
    {
        Name = name;
        Duration = duration;
        StartDate = startDate;
        Description = description;
    }
    
    public string Name { get; private set; }
    
    public DateTime Duration { get; private set; }
    
    public DateTime StartDate { get; private set; }
    
    public string Description { get; private set; }
    
    
    public ICollection<Exercise> Exercises { get; private set; } = new List<Exercise>();
    

    public static Workout Create(
        string name,
        DateTime duration,
        DateTime startDate,
        string description) =>
        new(WorkoutId.CreateUnique(), name, duration, startDate, description);
}