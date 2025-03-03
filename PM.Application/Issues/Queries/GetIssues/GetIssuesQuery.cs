using ErrorOr;
using MediatR;
using PM.Application.Issues.Common;

namespace PM.Application.Issues.Queries.GetIssues;

public record GetIssuesQuery(
    Guid UserId
) : IRequest<ErrorOr<IssuesResult>>;