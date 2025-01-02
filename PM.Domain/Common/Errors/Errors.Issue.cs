using ErrorOr;

namespace PM.Domain.Common.Errors;

public static partial class Errors
{
    public static class Issue
    {
        public static Error DuplicateIssue => Error.Validation(code: "Issue.DuplicateIssue",description: "Project đã tồn tại");

    }
}