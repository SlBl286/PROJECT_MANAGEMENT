using PM.Domain.ProjectAggregate;
using PM.Domain.ProjectAggregate.Entities;
using PM.Domain.ProjectAggregate.ValueObjects;
using PM.Domain.UserAggregate;
using PM.Domain.UserAggregate.ValueObjects;

namespace PM.Application.Common.Interfaces.Persistence;

public interface IProjectRepository : IRepository<Project,ProjectId>
{
    Task<bool> ExistsAsync(string code);
    Task<List<Project>> GetListByUserId(UserId userId);
    Task<List<Member>> GetMembers(ProjectId projecctId);
}