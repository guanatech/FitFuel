using Fitfuel.Shared.Entities;

namespace Fitfuel.Workouts.Domain.WorkoutPlanAggregate.ValueObjects;

public class WorkoutPlanId : ValueObject
{
    public Guid Value { get;}

    private WorkoutPlanId(Guid value) => 
        Value = value;
    
    public static WorkoutPlanId CreateUnique() => new(Guid.NewGuid());
    
    protected override IEnumerable<object?> GetAtomicValues()
    {
        yield return Value;
    }
}