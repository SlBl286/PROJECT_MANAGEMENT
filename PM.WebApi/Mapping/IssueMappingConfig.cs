using Mapster;
using PM.Application.Issues.Commands.CreateIssue;
using PM.Application.Issues.Common;
using PM.Application.Issues.Queries.GetIssues;
using PM.Application.Projects.Commands.CreateProject;
using PM.Application.Projects.Common;
using PM.Application.Projects.Queries.GetProjectMembers;
using PM.Application.Projects.Queries.GetProjects;
using PM.Domain.ProjectAggregate.Entities;
using PM.Presentation.Issue;
using PM.Presentation.Project;

namespace PM.WebApi.Mapping;

public class IssueMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {

        //Issue
        config.NewConfig<CreateIssueRequestWithReporterId, CreateIssueCommand>()
                    .Map(dest => dest, src => src);
        config.NewConfig<Guid, GetIssuesQuery>()
                    .Map(dest => dest.UserId, src => src);
        config.NewConfig<IssueResult, IssueResponse>()
                    .Map(dest => dest, src => src.Issue)
                    .Map(dest => dest.Id, src => src.Issue.Id.Value)
                    .Map(dest => dest.AssigneeId, src => src.Issue.AssigneeId.Value)
                    .Map(dest => dest.ProjectId, src => src.Issue.ProjectId.Value)
                    .Map(dest => dest.ReporterId, src => src.Issue.ReporterId.Value);

        config.NewConfig<IssuesResult, IssuesResponse>()
                    .Map(dest => dest.Issues, src => src.Issues);
    }
}
