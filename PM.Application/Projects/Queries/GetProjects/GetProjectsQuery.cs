using ErrorOr;
using MediatR;
using PM.Application.Projects.Common;
using PM.Domain.UserAggregate.ValueObjects;

namespace PM.Application.Projects.Queries.GetProjects;

public record GetProjectsQuery(
    Guid UserId
) : IRequest<ErrorOr<ProjectsResult>>;