using ErrorOr;
using MediatR;
using PM.Application.Projects.Common;

namespace PM.Application.Projects.Queries.GetProjectMembers;

public record GetProjectMembersQuery(
    Guid ProjectId
) : IRequest<ErrorOr<MembersResult>>;