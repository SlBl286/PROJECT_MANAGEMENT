using PM.Domain.Common.Models;

namespace PM.Domain.UserAggregate.ValueObjects;
public sealed class NotificationId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private NotificationId(Guid value)
    {
        Value = value;
    }

    public static NotificationId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
       public static NotificationId Create(Guid value)
    {
        return new(value);
    }
    public static NotificationId Create(string? value)
    {
        var newGuid = Guid.NewGuid();
        if (Guid.TryParse(value, out newGuid))
        {
            newGuid = Guid.Parse(value);
            return new NotificationId(newGuid);
        }
        else
            return new NotificationId(Guid.Empty);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}