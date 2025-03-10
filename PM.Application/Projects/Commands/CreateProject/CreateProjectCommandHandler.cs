using ErrorOr;
using MediatR;
using PM.Application.Projects.Common;
using PM.Application.Projects.Commands.CreateProject;
using PM.Application.Common.Interfaces.Persistence;
using PM.Domain.Common.Errors;
using PM.Domain.ProjectAggregate.Entities;
using PM.Domain.ProjectAggregate.ValueObjects;
using PM.Domain.ProjectAggregate;
using PM.Domain.UserAggregate.ValueObjects;
using PM.Domain.ProjectAggregate.Enums;

namespace PM.Application.Projects.Commands.CreateItem;

public class CreateItemCommandHandler : IRequestHandler<CreateProjectCommand, ErrorOr<ProjectResult>>
{
    private readonly IProjectRepository _projectRepository;
    public CreateItemCommandHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<ErrorOr<ProjectResult>> Handle(CreateProjectCommand command, CancellationToken cancellationToken)
    {
        if(await _projectRepository.ExistsAsync(command.Code))
        {
            return Errors.Project.DuplicateProject;
        }
        var members = command.MemberUserIds.ConvertAll(m=> Member.Create(MemberId.CreateUnique(),UserId.Create(m),MemerRole.Developer)).ToList();
        members.Add(Member.Create(MemberId.CreateUnique(),UserId.Create(command.CreatedById),MemerRole.ProjectManager));
        var item = Project.Create(ProjectId.CreateUnique(),
         command.Code,
         command.Name,
         command.Description,
         UserId.Create(command.CreatedById),
         members ?? []
         );
        await _projectRepository.Add(item);
        return new ProjectResult(item);
    }
}