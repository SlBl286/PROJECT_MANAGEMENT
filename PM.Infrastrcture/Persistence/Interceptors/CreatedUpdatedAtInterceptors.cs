using MediatR;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PM.Domain.Common.Models;

namespace PM.Infrastrcture.Persistence.Interceptors;

public class CreatedUpdatedAtInterceptors : SaveChangesInterceptor
{

    public CreatedUpdatedAtInterceptors(IMediator mediator)
    {
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        SaveChangeWithCreatedAndUpdated(eventData.Context).GetAwaiter().GetResult();
        return base.SavingChanges(eventData, result);
    }

    public async override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        await SaveChangeWithCreatedAndUpdated(eventData.Context);

        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private async Task SaveChangeWithCreatedAndUpdated(DbContext? dbContext)
    {
        await Task.CompletedTask;
        if (dbContext == null)
        {
            return;
        }

        var updatedEntities = dbContext.ChangeTracker.Entries<IBaseEntity>().Where(e =>  e.State == EntityState.Modified)
                        .Select(e => e.Entity).ToList();
         var createdEntities = dbContext.ChangeTracker.Entries<IBaseEntity>().Where(e => e.State == EntityState.Added )
                        .Select(e => e.Entity).ToList();
        foreach (var e in updatedEntities)
        {
           e.UpdatedAt = DateTime.UtcNow;
        }
        foreach (var e in createdEntities)
        {
           e.CreatedAt = DateTime.UtcNow;
           e.UpdatedAt = DateTime.UtcNow;
        }
    }
}