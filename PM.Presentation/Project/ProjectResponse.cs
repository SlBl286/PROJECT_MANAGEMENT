namespace PM.Presentation.Project;

public record ProjectResponse(
    string Id,
    string Code,
    string Name,
    string Description,
    string CreatedById,
    List<MemberRespone> Members,
    DateTime UpdatedAt
);
public record ProjectsResponse(
    List<ProjectResponse> Projects
);

public record MemberRespone(
   string UserId,
   int Role
);