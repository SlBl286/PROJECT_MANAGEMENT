using Mapster;
using PM.Application.Projects.Common;
using PM.Application.Users.Common;
using PM.Application.Users.Queries.GetUser;
using PM.Domain.ProjectAggregate.Entities;
using PM.Presentation.Project;
using PM.Presentation.User;

namespace PM.WebApi.Mapping;

public class ProjectMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
            config.NewConfig<Member, MemberRespone>()
                        .Map(dest => dest.UserId, src => src.UserId.Value);
        config.NewConfig<ProjectResult, ProjectResponse>()
                .Map(dest => dest, src => src.Project)
                .Map(dest => dest.Id, src => src.Project.Id.Value)
                .Map(dest => dest.CreatedById, src => src.Project.CreatedBy.Value)
                .Map(dest => dest.Members , src=> src.Project.Members);
    }
}
