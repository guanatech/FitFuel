using Fitfuel.Shared.Entities;
using Fitfuel.Workouts.Domain.WorkoutAggregate.ValueObjects;

namespace Fitfuel.Workouts.Domain.WorkoutAggregate;

public class Workout : AggregateRoot<WorkoutId>
{
    
    public string Name { get; private set; }
    
    public DateTime Duration { get; private set; }
    
    public DateTime StartDate { get; private set; }
    
    
    public Workout(WorkoutId id, string name, DateTime duration, DateTime startDate) : base(id)
    {
        Name = name;
        Duration = duration;
        StartDate = startDate;
    }


    public static Workout Create(string name, DateTime duration, DateTime startDate) =>
        new(WorkoutId.CreateUnique(), name, duration, startDate);
}