using Microsoft.EntityFrameworkCore;
using PM.Application.Common.Interfaces.Persistence;
using PM.Domain.UserAggregate;
using PM.Domain.UserAggregate.ValueObjects;

namespace PM.Infrastrcture.Persistence.Repositories;

public class UserRepository : Repository<User, UserId>, IUserRepository
{

    public UserRepository(PMDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<User?> GetUserByRefreshToken(string refreshToken)
    {
        var user = await _dbContext.Set<User>().AsNoTracking().FirstOrDefaultAsync(u => u.RefreshToken.Value == refreshToken);
        return user;
    }

    public async Task<bool> ExistsAsync(string username)
    {
        var user = await _dbContext.Set<User>().FirstOrDefaultAsync(u => u.Username == username);
        return user is not null;
    }

    public async Task<User?> GetUserByUsername(string username)
    {
        var user = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Username == username);
        return user;
    }

    public async Task<List<User>> GetList(Guid excludeId)
    {
        var users = await _dbContext.Set<User>().AsNoTracking().Where(u => u.Id != UserId.Create(excludeId) ).ToListAsync();
        return users;
    }
}
