using Fitfuel.Shared.Entities;

namespace Fitfuel.Auth.Domain.UserAggregate.ValueObjects;

public class UserId : ValueObject
{
    public Guid Value { get;}

    private UserId(Guid value) => 
        Value = value;
    
    public static UserId CreateUnique() => new(Guid.NewGuid());
    
    protected override IEnumerable<object?> GetAtomicValues()
    {
        yield return Value;
    }
}