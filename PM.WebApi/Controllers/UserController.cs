using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PM.Application.Users.Common;
using PM.Application.Users.Queries.GetUser;
using PM.Presentation.User;

namespace PM.WebApi.Controllers;

[Route("")]
public class UserController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public UserController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }


    [HttpGet("Current")]
    public async Task<IActionResult> GetUserInfor()
    {
        var traceId = HttpContext?.TraceIdentifier;
        var userId = Guid.Parse(GetCurrentUserId());
        var query = _mapper.Map<GetUserQuery>(userId);
        ErrorOr<UserResult> userResult = await _mediator.Send(query);
        return userResult.Match(
           userResult => Ok(_mapper.Map<UserResponse>(userResult)),
           errors => Problem(errors)
       );
    }

}
