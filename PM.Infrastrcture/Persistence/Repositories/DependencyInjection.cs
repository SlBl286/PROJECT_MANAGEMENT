using Microsoft.Extensions.DependencyInjection;
using PM.Application.Common.Interfaces.Persistence;

namespace PM.Infrastrcture.Persistence.Repositories;

public static class DependencyInjection
{

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}