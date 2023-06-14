using Fitfuel.Shared.Entities;

namespace Fitfuel.Workouts.Domain.WorkoutPlanAggregate.ValueObjects;

public class WorkoutId : ValueObject
{
    public Guid Value { get;}

    private WorkoutId(Guid value) => 
        Value = value;
    
    public static WorkoutId CreateUnique() => new(Guid.NewGuid());
    
    protected override IEnumerable<object?> GetAtomicValues()
    {
        yield return Value;
    }
}