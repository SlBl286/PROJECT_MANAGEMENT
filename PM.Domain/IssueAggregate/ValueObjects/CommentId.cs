using PM.Domain.Common.Models;

namespace PM.Domain.IssueAggregate.ValueObjects;
public sealed class CommentId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private CommentId(Guid value)
    {
        Value = value;
    }

    public static CommentId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public static CommentId Create(Guid value)
    {
        return new(value);
    }
    public static CommentId Create(string? value)
    {
        var newGuid = Guid.NewGuid();
        if (Guid.TryParse(value, out newGuid))
        {
            newGuid = Guid.Parse(value);
            return new CommentId(newGuid);
        }
        else
            return new CommentId(Guid.Empty);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}