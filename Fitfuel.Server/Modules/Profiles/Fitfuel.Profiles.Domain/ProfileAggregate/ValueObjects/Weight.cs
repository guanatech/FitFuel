using Fitfuel.Profiles.Domain.ProfileAggregate.Enums;
using Fitfuel.Shared.Entities;

namespace Fitfuel.Profiles.Domain.ProfileAggregate.ValueObjects;

public class Weight : ValueObject
{
    public WeightUnit Unit { get; init; }
    
    public double Value { get; init; }
    
    private Weight(WeightUnit unit, double value)
    {
        Unit = unit;
        Value = value;
    }

    public static Weight Create(WeightUnit unit, double value) => new(unit, value); 
    
    protected override IEnumerable<object?> GetAtomicValues()
    {
        yield return Unit;
        yield return Value;
    }
}