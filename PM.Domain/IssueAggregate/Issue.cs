using PM.Domain.Common.Models;
using PM.Domain.IssueAggregate.Entities;
using PM.Domain.IssueAggregate.Enums;
using PM.Domain.IssueAggregate.ValueObjects;
using PM.Domain.ProjectAggregate.ValueObjects;
using PM.Domain.UserAggregate.ValueObjects;

namespace PM.Domain.IssueAggregate;

public sealed class Issue : AggregatetRoot<IssueId, Guid>
{
    private readonly List<Comment> _comments = [];
    private readonly List<Attachment> _attachments = [];

    public string Code { get; private set; }
    public string Title { get; private set; }
    public string? Description { get; private set; }
    public IssueStatus Status { get; private set; }
    public IssuePriority Priority { get; private set; }
    public IssueType Type { get; private set; }
    public UserId AssigneeId { get; private set; }
    public UserId ReporterId { get; private set; }
    public ProjectId ProjectId { get; private set; }

    public IReadOnlyList<Comment> Comments => _comments.AsReadOnly();
    public IReadOnlyList<Attachment> Attachments => _attachments.AsReadOnly();

    private Issue(IssueId id,
                string code,
                 string title,
                 string description,
                 IssueStatus status,
                 IssuePriority priority,
                 IssueType type,
                 UserId assigneeId,
                UserId reporterId,
                 ProjectId projectId,
                 List<Comment> comments,
                 List<Attachment> attachments
                ) : base(id)
    {
        Code = code;
        Title = title;
        Description = description;
        Status = status;
        Priority = priority;
        Type = type;
        AssigneeId = assigneeId;
        ReporterId = reporterId;
        ProjectId = projectId;
        _comments = comments;
        _attachments = attachments;
    }

    public static Issue Create(IssueId id,
                string code,
                 string title,
                 string description,
                 IssueStatus status,
                 IssuePriority priority,
                 IssueType type,
                 UserId assigneeId,
                UserId reporterId,
                 ProjectId projectId,
                      List<Comment> comments,
                 List<Attachment> attachments)
    {
        return new Issue(id, code, title, description, status, priority, type, assigneeId, reporterId, projectId, comments, attachments);
    }

#pragma warning disable CS0618
    private Issue() { }
#pragma warning restore CS0618
}

