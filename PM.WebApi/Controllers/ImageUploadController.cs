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
        try
        {

            var _tempFolder = Path.Combine(Path.Combine(_env.ContentRootPath, "Data_Stores", "salt", "temp"));
            var fileName = _hashStringService.HashString(file.FileName + DateTime.Now.ToString()) + Path.GetExtension(file.FileName);
            using (var fs = System.IO.File.Create(Path.Combine(_tempFolder, fileName)))
            {
                await file.CopyToAsync(fs);
            }
            return Ok(fileName);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return NotFound();
        }

    }

    [HttpPost("RemoveFile")]
    public async Task<IActionResult> RemoveFile([FromBody]string fileName)
    {
        try
        {
            await Task.CompletedTask;
            var _tempFolder = Path.Combine(Path.Combine(_env.ContentRootPath, "Data_Stores", "salt", "temp"));
            if (System.IO.File.Exists(Path.Combine(_tempFolder, fileName)))
                System.IO.File.Delete(Path.Combine(_tempFolder, fileName));
            return Ok(fileName);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return NotFound();
        }

    }

}
