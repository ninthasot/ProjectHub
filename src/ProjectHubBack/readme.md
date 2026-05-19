# Migrations

All commands are run from the **solution root** — the folder containing the `.sln` file.

Open your terminal at `C:\Repositories\ProjectHub` before running any command. In Visual Studio you can do this via **View → Terminal**. In Windows Explorer, navigate to the folder and type `cmd` in the address bar.

---

## Identity Module

**Add a migration**
```bash
dotnet ef migrations add <MigrationName> --project src/ProjectHubBack/Modules/Identity/ProjectHub.Modules.Identity.Infrastructure/ProjectHub.Modules.Identity.Infrastructure.csproj --startup-project src/ProjectHubBack/ProjectHub.API/ProjectHub.API.csproj --context IdentityDbContext
```

**Remove last migration**
```bash
dotnet ef migrations remove --project src/ProjectHubBack/Modules/Identity/ProjectHub.Modules.Identity.Infrastructure/ProjectHub.Modules.Identity.Infrastructure.csproj --startup-project src/ProjectHubBack/ProjectHub.API/ProjectHub.API.csproj --context IdentityDbContext
```

**Apply migrations**
```bash
dotnet ef database update --project src/ProjectHubBack/Modules/Identity/ProjectHub.Modules.Identity.Infrastructure/ProjectHub.Modules.Identity.Infrastructure.csproj --startup-project src/ProjectHubBack/ProjectHub.API/ProjectHub.API.csproj --context IdentityDbContext
```

**Roll back to a specific migration**
```bash
dotnet ef database update <MigrationName> --project src/ProjectHubBack/Modules/Identity/ProjectHub.Modules.Identity.Infrastructure/ProjectHub.Modules.Identity.Infrastructure.csproj --startup-project src/ProjectHubBack/ProjectHub.API/ProjectHub.API.csproj --context IdentityDbContext
```

---

## Workspaces Module

**Add a migration**
```bash
dotnet ef migrations add <MigrationName> --project src/ProjectHubBack/Modules/Workspaces/ProjectHub.Modules.Workspaces.Infrastructure/ProjectHub.Modules.Workspaces.Infrastructure.csproj --startup-project src/ProjectHubBack/ProjectHub.API/ProjectHub.API.csproj --context WorkspaceDbContext
```

**Remove last migration**
```bash
dotnet ef migrations remove --project src/ProjectHubBack/Modules/Workspaces/ProjectHub.Modules.Workspaces.Infrastructure/ProjectHub.Modules.Workspaces.Infrastructure.csproj --startup-project src/ProjectHubBack/ProjectHub.API/ProjectHub.API.csproj --context WorkspaceDbContext
```

**Apply migrations**
```bash
dotnet ef database update --project src/ProjectHubBack/Modules/Workspaces/ProjectHub.Modules.Workspaces.Infrastructure/ProjectHub.Modules.Workspaces.Infrastructure.csproj --startup-project src/ProjectHubBack/ProjectHub.API/ProjectHub.API.csproj --context WorkspaceDbContext
```

**Roll back to a specific migration**
```bash
dotnet ef database update <MigrationName> --project src/ProjectHubBack/Modules/Workspaces/ProjectHub.Modules.Workspaces.Infrastructure/ProjectHub.Modules.Workspaces.Infrastructure.csproj --startup-project src/ProjectHubBack/ProjectHub.API/ProjectHub.API.csproj --context WorkspaceDbContext
```

---

> **Remove last migration** only works if the migration has not been applied to the database yet.
> **Roll back** uses `0` to revert all migrations: `dotnet ef database update 0 --project ... --context ...`