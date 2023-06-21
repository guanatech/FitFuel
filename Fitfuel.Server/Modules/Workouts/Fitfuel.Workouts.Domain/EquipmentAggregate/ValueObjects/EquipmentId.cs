using Fitfuel.Shared.Entities;

namespace Fitfuel.Workouts.Domain.EquipmentAggregate.ValueObjects;

public class EquipmentId : ValueObject
{
    public Guid Value { get;}

    public EquipmentId(Guid value) => 
        Value = value;
    
    public static EquipmentId CreateUnique() => new(Guid.NewGuid());
    
    protected override IEnumerable<object?> GetAtomicValues()
    {
        yield return Value;
    }
}