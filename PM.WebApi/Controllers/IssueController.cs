using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PM.Application.Issues.Commands.CreateIssue;
using PM.Application.Issues.Common;
using PM.Application.Issues.Queries.GetIssues;
using PM.Application.Projects.Common;
using PM.Application.Projects.Queries.GetProjects;
using PM.Presentation.Issue;
using PM.Presentation.Project;

namespace PM.WebApi.Controllers;
[Route("")]
public class IssueController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _env;

    public IssueController(IMediator mediator, IMapper mapper, IWebHostEnvironment env)
    {
        _mediator = mediator;
        _mapper = mapper;
        _env = env;
    }


    [HttpPost("Issues")]
    public async Task<IActionResult> Create([FromBody] CreateIssueRequest request)
    {
        var createIssueRequestWithReporterId = new CreateIssueRequestWithReporterId(request.ProjectId, request.Title, request.Description, request.AssigneeId, request.Priority, request.Type, Guid.Parse(GetCurrentUserId()));
        var command = _mapper.Map<CreateIssueCommand>(createIssueRequestWithReporterId);
        ErrorOr<IssueResult> issueResult = await _mediator.Send(command);
        return issueResult.Match(
            issueResult => Created("/Issues",_mapper.Map<IssueResponse>(issueResult)),
            errors => Problem(errors: errors)
        );
    }

    [HttpGet("Issues")]
    public async Task<IActionResult> Get([FromQuery] GetIssuesRequest request)
    {
        var traceId = HttpContext?.TraceIdentifier;
        Guid userId = request.Me ? Guid.Parse(GetCurrentUserId()) : Guid.Empty;
        var query = _mapper.Map<GetIssuesQuery>(userId);
        ErrorOr<IssuesResult> issuesResult = await _mediator.Send(query);
        return issuesResult.Match(
           issuesResult => Ok(_mapper.Map<IssuesResponse>(issuesResult)),
           errors => Problem(errors)
       );
    }
}