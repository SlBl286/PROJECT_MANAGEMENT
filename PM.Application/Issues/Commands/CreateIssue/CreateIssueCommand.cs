using ErrorOr;
using MediatR;
using PM.Application.Issues.Common;
using PM.Application.Projects.Common;
using PM.Domain.ProjectAggregate.Entities;

namespace PM.Application.Issues.Commands.CreateIssue;

public record CreateIssueCommand(
    Guid ProjectId,
    string Code,
    string Title,
    string Description,
    Guid AssigneeId,
    int Priority,
    int Type,
    Guid ReporterId
) : IRequest<ErrorOr<IssueResult>>;
