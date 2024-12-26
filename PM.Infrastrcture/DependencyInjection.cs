using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PM.Application.Common.Interfaces.Authentication;
using PM.Application.Common.Interfaces.Services;
using PM.Infrastrcture.Authentication;
using PM.Infrastrcture.Persistence;
using PM.Infrastrcture.Persistence.Interceptors;
using PM.Infrastrcture.Persistence.Repositories;
using PM.Infrastrcture.Services;
namespace PM.Infrastrcture;

public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfigurationManager configuration)
    {

        services.AddAuth(configuration);

        services.AddSingleton<IDatetimeProvider, DatetimeProvider>();
        services.AddSingleton<IHashStringService, HashStringService>();
        services.AddPersistence(configuration);
        return services;
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfigurationManager configuration)
    {
        var dbSettings = new DbSettings();
        configuration.Bind(DbSettings.SectionName, dbSettings);
        services.AddSingleton(Options.Create(dbSettings));
        services.AddDbContext<PMDbContext>(options => options.UseNpgsql(dbSettings.PMDb));
        services.AddScoped<PublishDomainEventsInterceptors>();
        services.AddScoped<CreatedUpdatedAtInterceptors>();
        services.AddRepositories();

        return services;
    }

    public static IServiceCollection AddAuth(this IServiceCollection services, IConfigurationManager configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);
        services.AddSingleton(Options.Create(jwtSettings));

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.Secret)
                    )
                });
        return services;

    }
}