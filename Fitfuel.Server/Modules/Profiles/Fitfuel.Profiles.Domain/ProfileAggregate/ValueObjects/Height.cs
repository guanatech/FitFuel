using ErrorOr;
using Fitfuel.Profiles.Domain.Common.Errors;
using Fitfuel.Profiles.Domain.ProfileAggregate.Enums;
using Fitfuel.Shared.Entities;

namespace Fitfuel.Profiles.Domain.ProfileAggregate.ValueObjects;

public class Height : ValueObject
{
    public HeightUnit Unit{ get; init; }
    
    public int Value { get; init; }
    
    private Height(HeightUnit unit, int value)
    {
        Unit = unit;
        Value = value;
    }

    public static ErrorOr<Height> Create(string unit, int value)
    {
        if (!Enum.TryParse<HeightUnit>(unit, true, out var heightUnit)) 
            return Errors.Profile.IncorrectHeightUnitFormat;
        
        var weight = new Height(heightUnit, value);
        return weight;
    }
    
    protected override IEnumerable<object?> GetAtomicValues()
    {
        yield return Unit;
        yield return Value;
    }
};