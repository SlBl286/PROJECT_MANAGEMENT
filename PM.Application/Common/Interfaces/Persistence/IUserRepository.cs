using PM.Domain.UserAggregate;
using PM.Domain.UserAggregate.ValueObjects;

namespace PM.Application.Common.Interfaces.Persistence;

public interface IUserRepository : IRepository<User,UserId>
{
    Task<User?> GetUserByUsername(string username);
    Task<bool> ExistsAsync(string username);
    Task<User?> GetUserByRefreshToken(string refreshToken);
}