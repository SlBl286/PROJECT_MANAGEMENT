using PM.Domain.Common.Models;
using PM.Domain.ProjectAggregate.Entities;
using PM.Domain.ProjectAggregate.ValueObjects;
using PM.Domain.UserAggregate.ValueObjects;

namespace PM.Domain.ProjectAggregate;

public sealed class Project : AggregatetRoot<ProjectId, Guid>
{
    private readonly List<Member> _members = [];

    public string Code { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public UserId CreatedBy { get; private set; }
    public IReadOnlyList<Member> Members => _members.AsReadOnly();

    private Project(ProjectId id,
    string code,
                 string name,
                 string description,
                 UserId createdBy,
                 List<Member> members) : base(id)
    {
        Code = code;
        Name = name;
        Description = description;
        CreatedBy = createdBy;
        _members = members;
    }

    public static Project Create(ProjectId id,
    string code,
                            string name,
                              string description,
                              UserId createdBy,
                              List<Member> members)
    {
        return new Project(id, code, name, description, createdBy, members);
    }

#pragma warning disable CS0618
    private Project() { }
#pragma warning restore CS0618
}

