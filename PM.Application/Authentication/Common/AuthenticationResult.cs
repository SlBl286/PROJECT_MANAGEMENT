using PM.Domain.UserAggregate;

namespace PM.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token
);