using ErrorOr;
using MediatR;
using PM.Application.Authentication.Common;

namespace PM.Application.Authentication.Commands.Refresh;

public record RefreshCommand(
    string RefreshToken
) : IRequest<ErrorOr<AuthenticationResult>>;