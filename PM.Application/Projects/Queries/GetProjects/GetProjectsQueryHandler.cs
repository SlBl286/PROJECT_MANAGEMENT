

using ErrorOr;
using MediatR;
using PM.Application.Common.Interfaces.Persistence;
using PM.Application.Projects.Common;
using PM.Application.Users.Common;
using PM.Domain.Common.Errors;
using PM.Domain.UserAggregate.ValueObjects;

namespace PM.Application.Projects.Queries.GetProjects;

public class GetProjectsQueryHandler :
    IRequestHandler<GetProjectsQuery, ErrorOr<ProjectsResult>>
{
    private readonly IProjectRepository _projectRepository;

    public GetProjectsQueryHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<ErrorOr<ProjectsResult>> Handle(GetProjectsQuery query, CancellationToken cancellationToken)
    {
        var projects = await _projectRepository.GetListByUserId(UserId.Create(query.UserId));

        return new ProjectsResult(projects.Select(p => new ProjectResult(p)).ToList());
    }
}