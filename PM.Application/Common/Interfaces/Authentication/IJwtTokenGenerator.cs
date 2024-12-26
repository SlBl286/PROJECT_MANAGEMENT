using PM.Domain.UserAggregate;

namespace PM.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}