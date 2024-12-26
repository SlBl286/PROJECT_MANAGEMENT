using Microsoft.EntityFrameworkCore;
using PM.Application.Common.Interfaces.Persistence;
using PM.Domain.Common.Models;

namespace PM.Infrastrcture.Persistence.Repositories;

public class Repository<T, TId> : IRepository<T, TId> where T : Entity<TId> where TId : notnull
{
    protected readonly PMDbContext _dbContext;

    public Repository(PMDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(T item)
    {
        var AddResult = await _dbContext.AddAsync(item);
        _dbContext.SaveChanges();
    }
    public async Task Update(T item)
    {
        var UpdateResult = _dbContext.Update(item);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(TId id)
    {
        var item = await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(u => u.Id.Equals(id));
        return item is not null;
    }

    public async Task<List<T>> GetList()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task AddRange(List<T> entities)
    {
        await _dbContext.AddRangeAsync(entities);
    }

    public async Task Delete(List<T> entities)
    {
        _dbContext.RemoveRange(entities);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(List<TId> ids)
    {
        var entities = await _dbContext.Set<T>().Where(ic => ids.Contains(ic.Id)).ToListAsync();
        _dbContext.RemoveRange(entities);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<T?> GetById(TId id)
    {
        var item = await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(u => u.Id.Equals(id));
        return item;
    }
}
