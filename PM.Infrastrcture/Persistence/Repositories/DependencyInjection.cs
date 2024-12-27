using Microsoft.Extensions.DependencyInjection;
using PM.Application.Common.Interfaces.Persistence;
using PM.Domain.ProjectAggregate;

namespace PM.Infrastrcture.Persistence.Repositories;

public static class DependencyInjection
{

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProjectRepository, ProjectRepository>();

        return services;
    }
}