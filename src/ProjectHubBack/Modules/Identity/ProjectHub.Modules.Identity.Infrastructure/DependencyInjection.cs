using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectHub.Modules.Identity.Domain.Interfaces;
using ProjectHub.Modules.Identity.Infrastructure.Persistence;
using ProjectHub.Modules.Identity.Infrastructure.Repositories;

namespace ProjectHub.Modules.Identity.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddIdentityModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IdentityDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsHistoryTable("__EFMigrationsHistory", IdentityInfrastructureConstants.SchemaName)));


        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
