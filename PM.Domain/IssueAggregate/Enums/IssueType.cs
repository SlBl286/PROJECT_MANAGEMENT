namespace PM.Domain.IssueAggregate.Enums;
public enum IssueType
{
    Bug,
    Task,
    Story,
    Epic
}

static class IssueTypeExtensions
{
    public static string From(this IssueType role)
    {
        return role switch
        {
            IssueType.Bug => "Bug",
            IssueType.Task => "Task",
            IssueType.Story => "Story",
            IssueType.Epic => "Epic",
            _ => throw new ArgumentOutOfRangeException("IssueType"),
        };
    }
}