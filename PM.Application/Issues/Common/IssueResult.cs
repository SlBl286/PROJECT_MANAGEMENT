using PM.Domain.IssueAggregate;

namespace PM.Application.Issues.Common;

public record IssueResult(
   Issue Issue
);
public record IssuesResult(
    List<IssueResult> Issues
);