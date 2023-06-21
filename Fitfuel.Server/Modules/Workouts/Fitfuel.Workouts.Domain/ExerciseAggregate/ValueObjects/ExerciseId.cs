using Fitfuel.Shared.Entities;

namespace Fitfuel.Workouts.Domain.ExerciseAggregate.ValueObjects;

public class ExerciseId : ValueObject
{
    public Guid Value { get;}

    public ExerciseId(Guid value) => 
        Value = value;
    
    public static ExerciseId CreateUnique() => new(Guid.NewGuid());
    
    protected override IEnumerable<object?> GetAtomicValues()
    {
        yield return Value;
    }
}