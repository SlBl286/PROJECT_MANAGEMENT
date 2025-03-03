using ErrorOr;
using MediatR;
using PM.Application.Common.Interfaces.Persistence;
using PM.Domain.Common.Errors;
using PM.Domain.ProjectAggregate.ValueObjects;
using PM.Domain.UserAggregate.ValueObjects;
using PM.Application.Issues.Common;
using PM.Domain.IssueAggregate;
using PM.Domain.IssueAggregate.ValueObjects;
using PM.Domain.IssueAggregate.Enums;

namespace PM.Application.Issues.Commands.CreateIssue;

public class CreateIssueCommandHandler : IRequestHandler<CreateIssueCommand, ErrorOr<IssueResult>>
{
    private readonly IIssueRepository _issueRepository;
    private readonly IProjectRepository _projectRepository;
    public CreateIssueCommandHandler(IIssueRepository issueRepository, IProjectRepository projectRepository)
    {
        _issueRepository = issueRepository;
        _projectRepository = projectRepository;
    }

    public async Task<ErrorOr<IssueResult>> Handle(CreateIssueCommand command, CancellationToken cancellationToken)
    {
        var projectId = ProjectId.Create(command.ProjectId);
        var project = await _projectRepository.GetById(projectId);
        var totalIssue = await _issueRepository.CountByProjectId(projectId);
        var issue = Issue.Create(IssueId.CreateUnique(), project!.Code + "-"+ (totalIssue+1).ToString(), command.Title, command.Description, IssueStatus.Open, (IssuePriority)command.Priority, (IssueType)command.Type, UserId.Create(command.AssigneeId), UserId.Create(command.ReporterId), ProjectId.Create(command.ProjectId), [], []);
        await _issueRepository.Add(issue);
        return new IssueResult(issue);
    }
}