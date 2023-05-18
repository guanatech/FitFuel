namespace Fitfuel.Shared.Entities;

public abstract class ValueObject : IEquatable<ValueObject>
{
    protected abstract IEnumerable<object?> GetAtomicValues();

    public bool Equals(ValueObject? other) =>
        Equals((object?)other);
    
    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType())
            return false;
        
        var valueObject = (ValueObject)obj;
        
        return GetAtomicValues().SequenceEqual(valueObject.GetAtomicValues());
    }

    public override int GetHashCode() =>
        GetAtomicValues()
            .Select(x => x?.GetHashCode() ?? 0)
            .Aggregate((x, y) => x ^ y);
    
    public static bool operator ==(ValueObject left, ValueObject right) =>
        left.Equals(right);
    
    public static bool operator !=(ValueObject left, ValueObject right) =>
        !left.Equals(right);
}