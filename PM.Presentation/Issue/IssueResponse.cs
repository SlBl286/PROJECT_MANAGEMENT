namespace PM.Presentation.Issue;

public record IssueResponse(
    string Id,
    string Code,
    string Title,
    string Description,
    string ReporterId,
    string AssigneeId,
    int Status,
    int Priority,
    int Type,
    string ProjectId,
    DateTime UpdatedAt
);
public record IssuesResponse(
    List<IssueResponse> Issues
);
// public record ProjectMemberResponse(
//    string UserId,
//    int Role
// );
// public record MemberResponse(
//    string UserId,
//    string Username,
//    int Role
// );

// public record MembersResponse(
//     List<MemberResponse> Members
// );