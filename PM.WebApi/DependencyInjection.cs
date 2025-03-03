
using PM.WebApi.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PM.WebApi.Common.Errors;
using Microsoft.OpenApi.Models;

namespace PM.WebApi;

public static class DependencyInjection
{

    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {

        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>();
        services.AddMapping();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
   {
       c.SwaggerDoc("v1", new OpenApiInfo { Title = "Project Management API", Version = "v1" });
       c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
       {
           Description = "JWT Authorization header using the Bearer scheme.",
           Name = "Authorization",
           In = ParameterLocation.Header,
           Type = SecuritySchemeType.Http,
           Scheme = "bearer"
       });
       c.AddSecurityRequirement(new OpenApiSecurityRequirement
       {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] {}
            }
       });
   });
   services.AddSignalR();
        services.AddCors();
        return services;
    }
}