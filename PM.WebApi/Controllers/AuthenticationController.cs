using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PM.Application.Authentication.Commands.Login;
using PM.Application.Authentication.Commands.Refresh;
using PM.Application.Authentication.Commands.Register;
using PM.Application.Authentication.Common;
using PM.Presentation.Authentication;
using LoginRequest = PM.Presentation.Authentication.LoginRequest;
using RegisterRequest = PM.Presentation.Authentication.RegisterRequest;

namespace PM.WebApi.Controllers;

[Route("")]
[AllowAnonymous]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors: errors)
        );
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginCommand>(request);
        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);
        return authResult.Match(
           authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
           errors => Problem(errors)
       );
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh(Presentation.Authentication.RefreshRequest request)
    {
        var query = _mapper.Map<RefreshCommand>(request);
        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);
        return authResult.Match(
           authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
           errors => Problem(errors)
       );
    }
}