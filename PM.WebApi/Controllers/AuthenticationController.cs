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
    private readonly IWebHostEnvironment _env;

    public AuthenticationController(IMediator mediator, IMapper mapper, IWebHostEnvironment env)
    {
        _mediator = mediator;
        _mapper = mapper;
        _env = env;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);
        if (!authResult.IsError && request.Avatar is not null)
        {
            var _tempFolder = Path.Combine(Path.Combine(_env.ContentRootPath, "Data_Stores", "salt", "temp"));
            var _avatarFolder = Path.Combine(Path.Combine(_env.ContentRootPath, "Data_Stores", "salt", "avatar"));
            if (System.IO.File.Exists(Path.Combine(_tempFolder, request.Avatar)))
                System.IO.File.Move(Path.Combine(_tempFolder, request.Avatar), Path.Combine(_avatarFolder, request.Avatar));
        }
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