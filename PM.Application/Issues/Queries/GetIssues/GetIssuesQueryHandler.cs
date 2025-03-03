

using ErrorOr;
using MediatR;
using PM.Application.Common.Interfaces.Persistence;
using PM.Application.Issues.Common;
using PM.Application.Projects.Common;
using PM.Domain.IssueAggregate;
using PM.Domain.UserAggregate.ValueObjects;

namespace PM.Application.Issues.Queries.GetIssues;

public class GetIssuesQueryHandler :
    IRequestHandler<GetIssuesQuery, ErrorOr<IssuesResult>>
{
    private readonly IProjectRepository _projectRepository;
    private readonly IIssueRepository _issueRepository;

    public GetIssuesQueryHandler(IProjectRepository projectRepository, IIssueRepository issueRepository)
    {
        _projectRepository = projectRepository;
        _issueRepository = issueRepository;
    }

    public async Task<ErrorOr<IssuesResult>> Handle(GetIssuesQuery query, CancellationToken cancellationToken)
    {
        var issues = new List<Issue>();
        if (query.UserId != Guid.Empty)
            issues = await _issueRepository.GetListByUserId(UserId.Create(query.UserId));
        else issues = await _issueRepository.GetList();
        return new IssuesResult(issues.Select(p => new IssueResult(p)).ToList());
    }
}