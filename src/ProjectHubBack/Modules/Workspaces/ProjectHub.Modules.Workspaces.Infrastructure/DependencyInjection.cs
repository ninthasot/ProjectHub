using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectHub.Modules.Workspaces.Infrastructure.Persistence;

namespace ProjectHub.Modules.Workspaces.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddWorkspaceModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<WorkspaceDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsHistoryTable("__EFMigrationsHistory", WorkspaceInfrastructureConstants.SchemaName)));

        return services;
    }
}
