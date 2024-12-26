using ErrorOr;
using MediatR;
using PM.Application.Authentication.Common;

namespace PM.Application.Authentication.Commands.Login;

public record LoginCommand(
    string Username,
    string Password
) : IRequest<ErrorOr<AuthenticationResult>>;