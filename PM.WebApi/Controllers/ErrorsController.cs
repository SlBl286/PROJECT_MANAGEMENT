using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using POS.Application.Common.Errors;
using Swashbuckle.AspNetCore.Annotations;

namespace PM.WebApi.Controllers;
public class ErrorsController : ControllerBase
{
    [SwaggerIgnore]
    [Route("/error")]
    public IActionResult Error()
    {
        Exception? exceptiton = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        var (statusCode, message) = exceptiton switch
        {
            IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
            _ => (StatusCodes.Status500InternalServerError, "An unexpected error occured."),
        };

        return Problem(statusCode: statusCode, title: message);
    }
}