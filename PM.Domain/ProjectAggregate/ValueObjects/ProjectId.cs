using PM.Domain.Common.Models;

namespace PM.Domain.ProjectAggregate.ValueObjects;
public sealed class ProjectId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private ProjectId(Guid value)
    {
        Value = value;
    }

    public static ProjectId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public static ProjectId Create(Guid value)
    {
        return new(value);
    }
    public static ProjectId Create(string? value)
    {
        var newGuid = Guid.NewGuid();
        if (Guid.TryParse(value, out newGuid))
        {
            newGuid = Guid.Parse(value);
            return new ProjectId(newGuid);
        }
        else
            return new ProjectId(Guid.Empty);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}