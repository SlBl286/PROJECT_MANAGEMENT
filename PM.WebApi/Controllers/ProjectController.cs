using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PM.Application.Projects.Commands.CreateProject;
using PM.Application.Projects.Common;
using PM.Application.Projects.Queries.GetProjectMembers;
using PM.Application.Projects.Queries.GetProjects;
using PM.Presentation.Project;

namespace PM.WebApi.Controllers;
[Route("")]
public class ProjectController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _env;

    public ProjectController(IMediator mediator, IMapper mapper, IWebHostEnvironment env)
    {
        _mediator = mediator;
        _mapper = mapper;
        _env = env;
    }


    [HttpPost("Projects")]
    public async Task<IActionResult> Create([FromBody] CreateProjectRequest request)
    {
        var ProjectRequestWithCreatedBy = new ProjectRequestWithCreatedBy(request.Code, request.Name, request.Description, GetCurrentUserId(), request.MemberUserIds);
        var command = _mapper.Map<CreateProjectCommand>(ProjectRequestWithCreatedBy);
        ErrorOr<ProjectResult> projectResult = await _mediator.Send(command);
        return projectResult.Match(
            projectResult => Ok(_mapper.Map<ProjectResponse>(projectResult)),
            errors => Problem(errors: errors)
        );
    }

    [HttpGet("Projects")]
    public async Task<IActionResult> GetProjects([FromQuery] GetProjectsRequest request)
    {
        var traceId = HttpContext?.TraceIdentifier;
        Guid userId = Guid.Parse(GetCurrentUserId());
        var query = _mapper.Map<GetProjectsQuery>(userId);
        ErrorOr<ProjectsResult> projectsResult = await _mediator.Send(query);
        return projectsResult.Match(
           projectsResult => Ok(_mapper.Map<ProjectsResponse>(projectsResult)),
           errors => Problem(errors)
       );
    }
    [HttpGet("Projects/{projectId:guid}/Members")]
    public async Task<IActionResult> GetUserMemberProjects([FromRoute] Guid projectId)
    {
        var query = _mapper.Map<GetProjectMembersQuery>(projectId);
        ErrorOr<MembersResult> membersResult = await _mediator.Send(query);
        return membersResult.Match(
           membersResult => Ok(_mapper.Map<MembersResponse>(membersResult)),
           errors => Problem(errors)
       );
    }
}