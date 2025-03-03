namespace PM.Presentation.Project;

public record ProjectResponse(
    string Id,
    string Code,
    string Name,
    string Description,
    string CreatedById,
    List<ProjectMemberResponse> Members,
    DateTime UpdatedAt
);
public record ProjectsResponse(
    List<ProjectResponse> Projects
);
public record ProjectMemberResponse(
   string UserId,
   int Role,
string Username
);
public record MemberResponse(
   string UserId,
   string Username,
   int Role
);

public record MembersResponse(
    List<MemberResponse> Members
);