using PM.Domain.ProjectAggregate.Entities;
using PM.Domain.UserAggregate;


namespace PM.Application.Projects.Common;

public record MemberResult(
   Member Member,
    string UserName
);


public record MembersResult(
    List<MemberResult> Members
);