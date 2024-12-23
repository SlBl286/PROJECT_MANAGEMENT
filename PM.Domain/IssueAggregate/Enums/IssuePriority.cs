namespace PM.Domain.IssueAggregate.Enums;
public enum IssuePriority
{
    Low,
    Medium,
    High,
    Critical
}

static class IssuePriorityExtensions
{
    public static string From(this IssuePriority role)
    {
        return role switch
        {
            IssuePriority.Low => "Low",
            IssuePriority.Medium => "Medium",
            IssuePriority.High => "High",
            IssuePriority.Critical => "Critical",
            _ => throw new ArgumentOutOfRangeException("IssuePriority"),
        };
    }
}