
using PM.WebApi.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PM.WebApi.Common.Errors;

namespace PM.WebApi;

public static class DependencyInjection
{

    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {

        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>();
        services.AddMapping();
        return services;
    }
}