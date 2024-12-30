

using ErrorOr;
using MediatR;
using PM.Application.Common.Interfaces.Persistence;
using PM.Application.Users.Common;
using PM.Domain.Common.Errors;
using PM.Domain.UserAggregate.ValueObjects;

namespace PM.Application.Users.Queries.GetUsers;

public class GetUsersQueryHandler :
    IRequestHandler<GetUsersQuery, ErrorOr<UsersResult>>
{
    private readonly IUserRepository _userRepository;

    public GetUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<UsersResult>> Handle(GetUsersQuery query, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetList(query.Id);

        return new UsersResult(users.Select(u => new UserResult(u)).ToList());
    }
}