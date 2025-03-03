

using ErrorOr;
using MediatR;
using PM.Application.Common.Interfaces.Persistence;
using PM.Application.Projects.Common;
using PM.Application.Users.Common;
using PM.Domain.Common.Errors;
using PM.Domain.ProjectAggregate;
using PM.Domain.ProjectAggregate.ValueObjects;
using PM.Domain.UserAggregate.ValueObjects;

namespace PM.Application.Projects.Queries.GetProject;

public class GetProjectQueryHandler :
    IRequestHandler<GetProjectQuery, ErrorOr<ProjectResult>>
{
    private readonly IProjectRepository _projectRepository;

    public GetProjectQueryHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<ErrorOr<ProjectResult>> Handle(GetProjectQuery query, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetById(ProjectId.Create(query.ProjectId));
        if (project is null)
            return Errors.Project.NotFound;
        return new ProjectResult(project);
    }
}