using ErrorOr;
using MediatR;
using PM.Application.Projects.Common;

namespace PM.Application.Projects.Queries.GetProject;

public record GetProjectQuery(
    Guid ProjectId
) : IRequest<ErrorOr<ProjectResult>>;