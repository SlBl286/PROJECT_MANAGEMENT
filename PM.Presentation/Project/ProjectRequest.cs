namespace PM.Presentation.Project;

public record ProjectRequest(
    string Code,
    string Name,
    string Description,
    string CreatedById,
    List<string> MemberUserIds
);