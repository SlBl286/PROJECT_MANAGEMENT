namespace PM.Presentation.Project;

public record CreateIssueRequest(
    Guid ProjectId,
    string Code,
    string Title,
    string Description,
    Guid AssigneeId,
    int Priority,
    int Type
);
public record CreateIssueRequestWithReporterId(
    Guid ProjectId,
    string Code,
    string Title,
    string Description,
    Guid AssigneeId,
    int Priority,
    int Type,
    Guid ReporterId
);