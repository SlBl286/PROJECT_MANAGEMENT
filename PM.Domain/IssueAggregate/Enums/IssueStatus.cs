namespace PM.Domain.IssueAggregate.Enums;
public enum IssueStatus
{
    Open,
    InProgress,
    Resolved,
    Closed
}

static class IssueStatusExtensions
{
    public static string From(this IssueStatus role)
    {
        return role switch
        {
            IssueStatus.Open => "Open",
            IssueStatus.InProgress => "InProgress",
            IssueStatus.Resolved => "Resolved",
            IssueStatus.Closed => "Closed",
            _ => throw new ArgumentOutOfRangeException("IssueStatus"),
        };
    }
}