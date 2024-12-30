using ErrorOr;
using MediatR;
using PM.Application.Users.Common;

namespace PM.Application.Users.Queries.GetUsers;

public record GetUsersQuery(
    Guid Id
) : IRequest<ErrorOr<UsersResult>>;