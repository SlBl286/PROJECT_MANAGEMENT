using ErrorOr;
using MediatR;
using PM.Application.Users.Common;

namespace PM.Application.Users.Queries.GetUser;

public record GetUserQuery(
    Guid Id
) : IRequest<ErrorOr<UserResult>>;