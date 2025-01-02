using Microsoft.EntityFrameworkCore;
using PM.Application.Common.Interfaces.Persistence;
using PM.Domain.ProjectAggregate;
using PM.Domain.ProjectAggregate.Entities;
using PM.Domain.ProjectAggregate.ValueObjects;
using PM.Domain.UserAggregate;
using PM.Domain.UserAggregate.ValueObjects;

namespace PM.Infrastrcture.Persistence.Repositories;

public class ProjectRepository : Repository<Project, ProjectId>, IProjectRepository
{

    public ProjectRepository(PMDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> ExistsAsync(string code)
    {
        var project = await _dbContext.Set<Project>().FirstOrDefaultAsync(u => u.Code == code);
        return project is not null;
    }

    public async Task<List<Project>> GetListByUserId(UserId userId)
    {
        var projects = await _dbContext.Set<Project>().Where(u => u.Members.Select(m=> m.UserId).Contains(userId)).ToListAsync();

        return projects;
    }

    public async Task<List<Member>> GetMembers(ProjectId projecctId)
    {
        var project = await _dbContext.Set<Project>().FirstOrDefaultAsync(p=> p.Id == projecctId);
        if( project is not null){

            return [.. project.Members];
        }

        return [];
    }
}
