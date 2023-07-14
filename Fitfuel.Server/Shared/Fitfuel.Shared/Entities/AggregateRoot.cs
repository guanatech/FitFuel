namespace Fitfuel.Shared.Entities;

public class AggregateRoot : Entity
{
    protected AggregateRoot(Guid id) : base(id) {}

    protected AggregateRoot() { }
}