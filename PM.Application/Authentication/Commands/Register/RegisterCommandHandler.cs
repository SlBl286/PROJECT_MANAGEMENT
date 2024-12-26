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

namespace PM.Application.Authentication.Commands.Register;

public class RegisterCommandHandler :
    IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IHashStringService _hashStringService;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, IHashStringService hashStringService)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
        _hashStringService = hashStringService;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        //Check if user already exists
        if (await _userRepository.ExistsAsync(command.Username))
        {
            return Errors.User.DuplicateUserName;
        }
        var hashedPassword = _hashStringService.HashPassword(command.Password, out byte[] salt);
        //Create user (generate unique ID)
        var user = User.Create(UserId.CreateUnique(),
                                command.FirstName,
                               command.Username,
                               command.PhoneNumber,
                               command.Avatar,
                               command.Address,
                               hashedPassword,
                               UserRole.User,
                               Convert.ToBase64String(salt),
                               RefreshToken.Create(DateTime.UtcNow.AddDays(7)));

        await _userRepository.Add(user);
        //Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);
    }
}