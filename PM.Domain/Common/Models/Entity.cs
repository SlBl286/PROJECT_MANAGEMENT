
namespace PM.Domain.Common.Models;

public abstract class Entity<TId> : IEquatable<Entity<TId>>, IHasDomainEvents, IBaseEntity
where TId : notnull
{
    private readonly List<IDomainEvent> _domainEvents = new();
    public TId Id { get; protected set; }

    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
   

    protected Entity(TId id)
    {
        Id = id;
    }


    public bool Equals(Entity<TId>? other)
    {
        return Equals((object?)other);
    }
    public static bool operator ==(Entity<TId> left, Entity<TId> right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Entity<TId> left, Entity<TId> right)
    {
        return !Equals(left, right);
    }
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType())
        {
            return false;
        }

        var valueObject = (ValueObject)obj;

        return Equals(valueObject);
    }
    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();

    }

#pragma warning disable CS0618
    protected Entity()
    { }
#pragma warning restore CS0618
}