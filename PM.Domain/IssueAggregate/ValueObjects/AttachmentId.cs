using PM.Domain.Common.Models;

namespace PM.Domain.IssueAggregate.ValueObjects;
public sealed class AttachmentId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private AttachmentId(Guid value)
    {
        Value = value;
    }

    public static AttachmentId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public static AttachmentId Create(Guid value)
    {
        return new(value);
    }
    public static AttachmentId Create(string? value)
    {
        var newGuid = Guid.NewGuid();
        if (Guid.TryParse(value, out newGuid))
        {
            newGuid = Guid.Parse(value);
            return new AttachmentId(newGuid);
        }
        else
            return new AttachmentId(Guid.Empty);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}