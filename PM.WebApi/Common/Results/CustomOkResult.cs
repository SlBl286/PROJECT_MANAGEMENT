using Microsoft.AspNetCore.Mvc;

namespace PM.WebApi.Common.Results;

public class CustomOkResult : IActionResult
{
    public Task ExecuteResultAsync(ActionContext context)
    {
        throw new NotImplementedException();
    }
}