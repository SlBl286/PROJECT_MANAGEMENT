using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PM.Application.Common.Interfaces.Services;
using PM.Application.Users.Common;
using PM.Application.Users.Queries.GetUser;
using PM.Presentation.User;

namespace PM.WebApi.Controllers;

[AllowAnonymous]
[Route("")]
public class ImageUploadController : ApiController
{
    private readonly IWebHostEnvironment _env;
    private readonly IHashStringService _hashStringService;
    public ImageUploadController(IWebHostEnvironment env, IHashStringService hashStringService)
    {
        _env = env;
        _hashStringService = hashStringService;
    }


    [HttpPost("UploadFile")]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        var _tempFolder = Path.Combine(Path.Combine(_env.ContentRootPath, "Data_Stores", "salt", "temp"));
        var fileName = _hashStringService.HashString(file.FileName)+ Path.GetExtension(file.FileName);
        using(var fs = new FileStream(Path.Combine(_tempFolder,fileName), FileMode.OpenOrCreate)){
            await file.CopyToAsync(fs);
        }
        return Ok(fileName);
    }

}
