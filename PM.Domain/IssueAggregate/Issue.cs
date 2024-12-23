using PM.Domain.Common.Models;
using PM.Domain.IssueAggregate.Enums;
using PM.Domain.IssueAggregate.ValueObjects;
using PM.Domain.ProjectAggregate.ValueObjects;
using PM.Domain.UserAggregate.ValueObjects;

namespace PM.Domain.IssueAggregate;

public sealed class Issue : AggregatetRoot<IssueId, Guid>
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public IssueStatus Status { get; private set; }
    public IssuePriority Priority { get; private set; }
    public IssueType Type { get; private set; }
    public UserId AssigneeId { get; private set; }
    public UserId ReporterId { get; private set; }

    public ProjectId ProjectId { get; private set; }
    private Issue(IssueId id,
                 string title,
                 string description,
                 IssueStatus status,
                 IssuePriority priority,
                 IssueType type,
                 UserId assigneeId,
                UserId reporterId,
                 ProjectId projectId
                ) : base(id)
    {
        Title = title;
        Description = description;
        Status = status;
        Priority = priority;
        Type = type;
        AssigneeId = assigneeId;
        ReporterId = reporterId;
        ProjectId = projectId;
    }

    public static Issue Create(IssueId id,
                 string title,
                 string description,
                 IssueStatus status,
                 IssuePriority priority,
                 IssueType type,
                 UserId assigneeId,
                UserId reporterId,
                 ProjectId projectId)
    {
        return new Issue(id, title, description, status, priority, type, assigneeId, reporterId, projectId);
    }

#pragma warning disable CS0618
    private Issue() { }
#pragma warning restore CS0618
}

