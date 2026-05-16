# Migrations

All commands are run from the **solution root**.

## Parameters

Each command targets a specific module. Adjust these three parameters depending on which module you are working on:

| Parameter | Description | Example |
|---|---|---|
| `--project` | Path to the module's Infrastructure project | `src/ProjectHubBack/Modules/Identity/ProjectHub.Modules.Identity.Infrastructure/ProjectHub.Modules.Identity.Infrastructure.csproj` |
| `--startup-project` | Always the API project | `src/ProjectHubBack/ProjectHub.API/ProjectHub.API.csproj` |
| `--context` | The DbContext for that module | `IdentityDbContext` |

The examples below use the **Identity** module. Swap the `--project` and `--context` values for other modules.

## Add a migration

```bash
dotnet ef migrations add <MigrationName> --project src/ProjectHubBack/Modules/Identity/ProjectHub.Modules.Identity.Infrastructure/ProjectHub.Modules.Identity.Infrastructure.csproj --startup-project src/ProjectHubBack/ProjectHub.API/ProjectHub.API.csproj --context IdentityDbContext
```

## Remove last migration

```bash
dotnet ef migrations remove --project src/ProjectHubBack/Modules/Identity/ProjectHub.Modules.Identity.Infrastructure/ProjectHub.Modules.Identity.Infrastructure.csproj --startup-project src/ProjectHubBack/ProjectHub.API/ProjectHub.API.csproj --context IdentityDbContext
```

> Only works if the migration has not been applied to the database yet.

## Apply migrations

```bash
dotnet ef database update --project src/ProjectHubBack/Modules/Identity/ProjectHub.Modules.Identity.Infrastructure/ProjectHub.Modules.Identity.Infrastructure.csproj --startup-project src/ProjectHubBack/ProjectHub.API/ProjectHub.API.csproj --context IdentityDbContext
```

## Roll back to a specific migration

```bash
dotnet ef database update <MigrationName> --project src/ProjectHubBack/Modules/Identity/ProjectHub.Modules.Identity.Infrastructure/ProjectHub.Modules.Identity.Infrastructure.csproj --startup-project src/ProjectHubBack/ProjectHub.API/ProjectHub.API.csproj --context IdentityDbContext
```
