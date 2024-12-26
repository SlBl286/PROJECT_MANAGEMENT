using System.Net;

namespace POS.Application.Common.Errors;

public interface IServiceException
{
    public string ErrorMessage { get; }
    public HttpStatusCode StatusCode { get; }
}