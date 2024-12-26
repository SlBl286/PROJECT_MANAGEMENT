

using ErrorOr;
using MediatR;
using PM.Application.Authentication.Common;
using PM.Application.Common.Interfaces.Authentication;
using PM.Application.Common.Interfaces.Persistence;
using PM.Application.Common.Interfaces.Services;
using PM.Domain.Common.Errors;
using PM.Domain.UserAggregate;
using PM.Domain.UserAggregate.ValueObjects;

namespace PM.Application.Authentication.Commands.Refresh;

public class RefreshCommandHandler :
    IRequestHandler<RefreshCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RefreshCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RefreshCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByRefreshToken(command.RefreshToken);
        if (user is null || user.RefreshToken.ExpireTime < DateTime.UtcNow)
        {
            return Errors.Authentication.InvalidRefreshToken;
        }
        var userUpdate = User.Create(user.Id,
                                     user.Name,
                                     user.Username,
                                     user.Email,
                                     user.PhoneNumber,
                                     user.Avatar,
                                     user.HashedPassword,
                                     user.Role,
                                     user.Salt,
                                     RefreshToken.Create(DateTime.UtcNow.AddDays(7)));
        await _userRepository.Update(userUpdate);
        var token = _jwtTokenGenerator.GenerateToken(userUpdate);
        return new AuthenticationResult(userUpdate, token);
    }
}