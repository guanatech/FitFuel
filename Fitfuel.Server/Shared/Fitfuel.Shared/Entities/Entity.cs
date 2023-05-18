namespace Fitfuel.Shared.Entities;

public abstract class Entity<TId> : IEquatable<Entity<TId>>
    where TId : notnull
{
    public TId Id {get;}
    
    protected Entity(TId id)
    {
        if(!IsValid(id))
            throw new ArgumentException("Identifier is not a supported format");
        Id = id;
    }
    
    public bool Equals(Entity<TId>? other) =>
        Equals((object?)other);
    
    public override bool Equals(object? obj) =>
        obj is Entity<TId> entity && Id.Equals(entity.Id);
    
    public override int GetHashCode() =>
        Id.GetHashCode();
    
    public static bool operator ==(Entity<TId> left, Entity<TId> right) =>
        left.Equals(right);
    
    public static bool operator !=(Entity<TId> left, Entity<TId> right) =>
        !left.Equals(right);
    
    private static bool IsValid(TId id) =>
        id is int or long or Guid;
    
    
    #pragma warning disable CS8618
        protected Entity() { }
    #pragma warning restore CS8618
}