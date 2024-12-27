using ErrorOr;
using MediatR;
using PM.Application.Authentication.Common;

namespace PM.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string Name,
    string Username,
    string Password,
    string? Email,
    string? PhoneNumber,
    string? Avatar,
    DateTime? BirthDay
) : IRequest<ErrorOr<AuthenticationResult>>;