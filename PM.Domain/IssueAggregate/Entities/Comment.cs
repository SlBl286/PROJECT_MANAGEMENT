using PM.Domain.Common.Models;
using PM.Domain.IssueAggregate.ValueObjects;
using PM.Domain.UserAggregate.ValueObjects;

namespace PM.Domain.IssueAggregate.Entities;

public sealed class Comment : Entity<CommentId>
{
    public string Content { get; private set; }
    public UserId UserId { get; private set; }

    private Comment(CommentId id, string content,UserId userId) : base(id)
    {
        Content = content;
       UserId = userId;
    }
    public static Comment Create(CommentId id, string content,UserId userId)
    {
        return new Comment(id,content, userId);    
    }

#pragma warning disable CS0618
    private Comment() { }
#pragma warning restore CS0618
}