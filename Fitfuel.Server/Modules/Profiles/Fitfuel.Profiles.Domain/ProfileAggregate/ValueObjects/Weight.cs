using Fitfuel.Profiles.Domain.ProfileAggregate.Enums;
using Fitfuel.Shared.Entities;
using ErrorOr;
using Fitfuel.Profiles.Domain.Common.Errors;

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

    public static ErrorOr<Weight> Create(string unit, double value)
    {
        if (!Enum.TryParse<WeightUnit>(unit, true, out var weightUnit)) 
            return Errors.Profile.IncorrectWeightUnitFormat;
        
        var weight = new Weight(weightUnit, value);
        return weight;
    }
    
    protected override IEnumerable<object?> GetAtomicValues()
    {
        yield return Unit;
        yield return Value;
    }
}