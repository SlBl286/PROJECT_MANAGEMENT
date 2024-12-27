using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PM.Application.Projects.Commands.CreateProject;
using PM.Application.Projects.Common;
using PM.Presentation.Project;

namespace PM.WebApi.Controllers;
[Route("")]
public class ProjectController : ApiController{
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
    public async Task<IActionResult> Create([FromBody]ProjectRequest request){
        var requestWithUserId = new ProjectRequest(request.Code, request.Name, request.Description,GetCurrentUserId());
         var command = _mapper.Map<CreateProjectCommand>(requestWithUserId);
        ErrorOr<ProjectResult> projectResult = await _mediator.Send(command);
       
        return projectResult.Match(
            projectResult => Ok(_mapper.Map<ProjectResponse>(projectResult)),
            errors => Problem(errors: errors)
        );
    }

}