using Fitfuel.Shared.Entities;

namespace Fitfuel.Meals.Domain.MealAggregate.ValueObjects;

public class MealId: ValueObject
{
    public Guid Value { get;}

    private MealId(Guid value) => 
        Value = value;
    
    public static MealId CreateUnique() => new(Guid.NewGuid());
    
    protected override IEnumerable<object?> GetAtomicValues()
    {
        yield return Value;
    }
}