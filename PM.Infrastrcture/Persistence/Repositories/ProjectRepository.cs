using Microsoft.EntityFrameworkCore;
using PM.Application.Common.Interfaces.Persistence;
using PM.Domain.ProjectAggregate;
using PM.Domain.ProjectAggregate.ValueObjects;
using PM.Domain.UserAggregate;

namespace PM.Infrastrcture.Persistence.Repositories;

public class ProjectRepository : Repository<Project, ProjectId>, IProjectRepository
{

    public ProjectRepository(PMDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> ExistsAsync(string code)
    {
        var user = await _dbContext.Set<Project>().FirstOrDefaultAsync(u => u.Code == code);
        return user is not null;
    }


}
