using Fitfuel.Shared.Entities;

namespace Fitfuel.Auth.Domain.UserAggregate.ValueObjects;

public class Email : ValueObject
{
    public string Value { get; }

    private Email(string value) => 
        Value = value;

    protected override IEnumerable<object?> GetAtomicValues()
    {
        yield return Value;
    }
}