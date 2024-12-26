using System.Diagnostics;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using PM.WebApi.Common.Http;

namespace PM.WebApi.Common.Errors;

public class CustomProblemDetailsFactory : ProblemDetailsFactory
{
    private readonly ApiBehaviorOptions _options;

    public CustomProblemDetailsFactory(IOptions<ApiBehaviorOptions> options)
    {
        _options = options.Value ?? throw new ArgumentNullException(nameof(options));
    }

    public override ProblemDetails CreateProblemDetails(
        HttpContext httpContext,
        int? statusCode = null,
         string? title = null,
         string? type = null,
         string? detail = null,
         string? instance = null)
    {
        statusCode ??= 500;

        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Type = type,
            Detail = detail,
            Instance = instance,
            Title = title,

        };

        ApplyProblemDetailsDefault(httpContext, problemDetails, statusCode.Value);
        return problemDetails;
    }

    public override ValidationProblemDetails CreateValidationProblemDetails(HttpContext httpContext, ModelStateDictionary modelStateDictionary, int? statusCode = null, string? title = null, string? type = null, string? detail = null, string? instance = null)
    {
        statusCode ??= 400;

        var problemDetails = new ValidationProblemDetails
        {
            Status = statusCode,
            Type = type,
            Detail = detail,
            Instance = instance,


        };
        if (title != null)
        {
            problemDetails.Title = title;
        }
        ApplyProblemDetailsDefault(httpContext, problemDetails, statusCode.Value);
        return problemDetails;
    }

    private void ApplyProblemDetailsDefault(HttpContext httpContext, ProblemDetails problemDetails, int statusCode)
    {
        problemDetails.Status ??= statusCode;

        if (_options.ClientErrorMapping.TryGetValue(statusCode, out var clientErrorData))
        {
            problemDetails.Title ??= clientErrorData.Title;
            problemDetails.Type ??= clientErrorData.Link;
        }

        var traceId = Activity.Current?.Id ?? httpContext?.TraceIdentifier;

        if (traceId != null)
        {
            problemDetails.Extensions["traceId"] = traceId;
        }


        if (httpContext?.Items[HttpContextItemKeys.Errors] is List<Error> errors)
        {
            //problemDetails.Extensions["errors"] = errors;
            problemDetails.Extensions.Add("errorCodes", errors?.Select(e => e.Code));
        }
        problemDetails.Extensions.Add("success", false);

    }
}