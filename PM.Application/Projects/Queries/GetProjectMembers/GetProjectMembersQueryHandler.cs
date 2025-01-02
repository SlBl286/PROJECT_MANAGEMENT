

using ErrorOr;
using MediatR;
using PM.Application.Common.Interfaces.Persistence;
using PM.Application.Projects.Common;
using PM.Application.Users.Common;
using PM.Domain.Common.Errors;
using PM.Domain.ProjectAggregate.ValueObjects;
using PM.Domain.UserAggregate.ValueObjects;

namespace PM.Application.Projects.Queries.GetProjectMembers;

public class GetProjectMembersQueryHandler :
    IRequestHandler<GetProjectMembersQuery, ErrorOr<MembersResult>>
{
    private readonly IProjectRepository _projectRepository;
    private readonly IUserRepository _userRepository;

    public GetProjectMembersQueryHandler(IProjectRepository projectRepository, IUserRepository userRepository)
    {
        _projectRepository = projectRepository;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<MembersResult>> Handle(GetProjectMembersQuery query, CancellationToken cancellationToken)
    {
        var members = await _projectRepository.GetMembers(ProjectId.Create(query.ProjectId));

         List<MemberResult> result = [];

        foreach (var item in members)
        {
            var user = await _userRepository.GetById(item.UserId);
            var newItem =  new MemberResult(item,user?.Username ?? "");
            result.Add(newItem);
        }

        return new MembersResult(result);
    }
}