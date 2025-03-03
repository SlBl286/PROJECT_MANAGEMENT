using Microsoft.EntityFrameworkCore;
using PM.Application.Common.Interfaces.Persistence;
using PM.Domain.IssueAggregate;
using PM.Domain.IssueAggregate.ValueObjects;
using PM.Domain.ProjectAggregate.ValueObjects;
using PM.Domain.UserAggregate.ValueObjects;

namespace PM.Infrastrcture.Persistence.Repositories;

public class IssueRepository : Repository<Issue, IssueId>, IIssueRepository
{

    public IssueRepository(PMDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<int> CountByProjectId(ProjectId projectId)
    {
        return  await _dbContext.Set<Issue>().Where(x => x.ProjectId == projectId).CountAsync();
    }

    public async Task<bool> ExistsAsync(string code)
    {
        var project = await _dbContext.Set<Issue>().FirstOrDefaultAsync(u => u.Code == code);
        return project is not null;
    }

    public async Task<List<Issue>> GetListByProjectId(ProjectId projectId)
    {
          var issues = await _dbContext.Set<Issue>().Where(i=> i.ProjectId == projectId).ToListAsync();
        return issues;
    }

    public async Task<List<Issue>> GetListByUserId(UserId userId)
    {
        var issues = await _dbContext.Set<Issue>().Where(i=> i.AssigneeId == userId).ToListAsync();
        return issues;
    }
}
