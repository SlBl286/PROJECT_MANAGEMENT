using ErrorOr;
using MediatR;
using PM.Application.Authentication.Common;

namespace PM.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string Username,
    string FirstName,
    string LastName,
    string? Email,
    string? PhoneNumber,
    DateTime Birthday,
    string? Avatar,
    string? Address,
    string Password
) : IRequest<ErrorOr<AuthenticationResult>>;