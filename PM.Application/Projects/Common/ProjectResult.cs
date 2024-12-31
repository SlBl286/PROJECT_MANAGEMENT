
using PM.Domain.ProjectAggregate;
using PM.Domain.UserAggregate;

namespace PM.Application.Projects.Common;

public record ProjectResult(
   Project Project
);


public record ProjectsResult(
    List<ProjectResult> Projects
);