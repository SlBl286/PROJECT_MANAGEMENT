using Mapster;
using PM.Application.Projects.Commands.CreateProject;
using PM.Application.Projects.Common;
using PM.Application.Projects.Queries.GetProjectMembers;
using PM.Application.Projects.Queries.GetProjects;
using PM.Application.Users.Common;
using PM.Application.Users.Queries.GetUser;
using PM.Domain.ProjectAggregate.Entities;
using PM.Presentation.Project;
using PM.Presentation.User;

namespace PM.WebApi.Mapping;

public class IssueMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //Members
        config.NewConfig<Guid,GetProjectMembersQuery>()
                    .Map(dest  => dest.ProjectId, src=> src);
        config.NewConfig<MemberResult, MemberResponse>()
                    .Map(dest => dest.UserId, src => src.Member.Id.Value)
                    .Map(dest => dest.Username, src => src.UserName)
                    .Map(dest => dest, src => src.Member);
        config.NewConfig<MembersResult, MembersResponse>()
                    .Map(dest => dest.Members, src => src.Members);

        //Project
        config.NewConfig<Member, ProjectMemberResponse>()
                    .Map(dest => dest.UserId, src => src.UserId.Value);
        config.NewConfig<ProjectRequestWithCreatedBy,CreateProjectCommand>()
                    .Map(dest  => dest, src=> src);
        config.NewConfig<Guid,GetProjectsQuery>()
                    .Map(dest  => dest.UserId, src=> src);
        config.NewConfig<ProjectResult, ProjectResponse>()
                    .Map(dest => dest, src => src.Project)
                    .Map(dest => dest.Id, src => src.Project.Id.Value)
                    .Map(dest => dest.CreatedById, src => src.Project.CreatedBy.Value)
                    .Map(dest => dest.Members, src => src.Project.Members);
        config.NewConfig<ProjectsResult, ProjectsResponse>()
                    .Map(dest => dest.Projects, src => src.Projects);
    }
}
