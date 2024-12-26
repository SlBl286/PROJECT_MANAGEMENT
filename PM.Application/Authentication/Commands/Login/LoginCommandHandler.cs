

using ErrorOr;
using MediatR;
using PM.Application.Authentication.Common;
using PM.Application.Common.Interfaces.Authentication;
using PM.Application.Common.Interfaces.Persistence;
using PM.Application.Common.Interfaces.Services;
using PM.Domain.Common.Errors;
using PM.Domain.UserAggregate;
using PM.Domain.UserAggregate.Enums;
using PM.Domain.UserAggregate.ValueObjects;

namespace PM.Application.Authentication.Commands.Login;

public class LoginCommandHandler :
    IRequestHandler<LoginCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRePMitory;
    private readonly IHashStringService _hashStringService;

    public LoginCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRePMitory, IHashStringService hashStringService)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRePMitory = userRePMitory;
        _hashStringService = hashStringService;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginCommand query, CancellationToken cancellationToken)
    {
        var user = await _userRePMitory.GetUserByUsername(query.Username);
        if (user is null)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        if (!_hashStringService.VerifyPassword(query.Password, user.HashedPassword, Convert.FromBase64String(user.Salt)))
        {
            return Errors.Authentication.InvalidCredentials;
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
        await _userRePMitory.Update(userUpdate);
        var token = _jwtTokenGenerator.GenerateToken(userUpdate);
        return new AuthenticationResult(userUpdate, token);
    }
}