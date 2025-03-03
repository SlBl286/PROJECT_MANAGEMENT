using PM.Domain.IssueAggregate;
using PM.Domain.IssueAggregate.ValueObjects;
using PM.Domain.ProjectAggregate.ValueObjects;
using PM.Domain.UserAggregate.ValueObjects;

namespace PM.Application.Common.Interfaces.Persistence;

public interface IIssueRepository : IRepository<Issue,IssueId>
{
    Task<bool> ExistsAsync(string code);
    Task<List<Issue>> GetListByUserId(UserId userId);

    Task<List<Issue>> GetListByProjectId(ProjectId projectId);
    Task<int> CountByProjectId(ProjectId projectId);

}