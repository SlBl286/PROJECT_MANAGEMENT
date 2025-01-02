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
    public CreateIssueCommandHandler(IIssueRepository issueRepository)
    {
        _issueRepository = issueRepository;
    }

    public async Task<ErrorOr<IssueResult>> Handle(CreateIssueCommand command, CancellationToken cancellationToken)
    {
        if (await _issueRepository.ExistsAsync(command.Code))
        {
            return Errors.Issue.DuplicateIssue;
        }
        var issue = Issue.Create(IssueId.CreateUnique(), command.Code, command.Title, command.Description, IssueStatus.Open, (IssuePriority)command.Priority, (IssueType)command.Type, UserId.Create(command.AssigneeId), UserId.Create(command.ReporterId), ProjectId.Create(command.ProjectId), [], []);
        await _issueRepository.Add(issue);
        return new IssueResult(issue);
    }
}