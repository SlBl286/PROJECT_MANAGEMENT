using PM.Domain.Common.Models;

namespace PM.Domain.UserAggregate.ValueObjects;
public sealed class UserId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private UserId(Guid value)
    {
        Value = value;
    }

    public static UserId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
       public static UserId Create(Guid value)
    {
        return new(value);
    }
    public static UserId Create(string? value)
    {
        var newGuid = Guid.NewGuid();
        if (Guid.TryParse(value, out newGuid))
        {
            newGuid = Guid.Parse(value);
            return new UserId(newGuid);
        }
        else
            return new UserId(Guid.Empty);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}