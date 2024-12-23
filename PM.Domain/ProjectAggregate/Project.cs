using PM.Domain.Common.Models;
using PM.Domain.ProjectAggregate.ValueObjects;
using PM.Domain.UserAggregate.ValueObjects;

namespace PM.Domain.ProjectAggregate;

public sealed class Project : AggregatetRoot<ProjectId, Guid>
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public UserId CreatedBy { get; private set; }
    private Project(ProjectId id,
                 string name,
                 string description,
                 UserId createdBy) : base(id)
    {
        Name = name;
        Description = description;
        CreatedBy = createdBy;
    }

    public static Project Create(ProjectId id,
                            string name,
                              string description,
                              UserId userId)
    {
        return new Project(id, name, description, userId);
    }

#pragma warning disable CS0618
    private Project() { }
#pragma warning restore CS0618
}

