

using ErrorOr;
using MediatR;
using PM.Application.Common.Interfaces.Persistence;
using PM.Application.Users.Common;
using PM.Domain.Common.Errors;
using PM.Domain.UserAggregate.ValueObjects;

namespace PM.Application.Users.Queries.GetUser;

public class GetUserQueryHandler :
    IRequestHandler<GetUserQuery, ErrorOr<UserResult>>
{
    private readonly IUserRepository _userRepository;

    public GetUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<UserResult>> Handle(GetUserQuery query, CancellationToken cancellationToken)
    {
        var item = await _userRepository.GetById(UserId.Create(query.Id));
        if (item is null)
        {
            return Errors.User.DuplicateUserName;
        }

        return new UserResult(item);
    }
}