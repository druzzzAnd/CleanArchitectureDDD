using Application.Interfaces.Providers;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Infrastructure.Providers;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Repositories
        services.AddScoped<IUserRepository, UserRepository>();

        // Message Bus
        services.AddScoped<IMessageBusService, MessageBusService>();

        // UoW & UoW Factory
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUnitOfWorkFactory, UnitOfWorkFactory>();

        return services;
    }
}
