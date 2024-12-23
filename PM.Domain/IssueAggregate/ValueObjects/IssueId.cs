using PM.Domain.Common.Models;

namespace PM.Domain.IssueAggregate.ValueObjects;
public sealed class IssueId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private IssueId(Guid value)
    {
        Value = value;
    }

    public static IssueId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public static IssueId Create(Guid value)
    {
        return new(value);
    }
    public static IssueId Create(string? value)
    {
        var newGuid = Guid.NewGuid();
        if (Guid.TryParse(value, out newGuid))
        {
            newGuid = Guid.Parse(value);
            return new IssueId(newGuid);
        }
        else
            return new IssueId(Guid.Empty);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}