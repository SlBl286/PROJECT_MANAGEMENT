using PM.Domain.Common.Models;

namespace PM.Domain.ProjectAggregate.ValueObjects;
public sealed class MemberId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private MemberId(Guid value)
    {
        Value = value;
    }

    public static MemberId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public static MemberId Create(Guid value)
    {
        return new(value);
    }
    public static MemberId Create(string? value)
    {
        var newGuid = Guid.NewGuid();
        if (Guid.TryParse(value, out newGuid))
        {
            newGuid = Guid.Parse(value);
            return new MemberId(newGuid);
        }
        else
            return new MemberId(Guid.Empty);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}