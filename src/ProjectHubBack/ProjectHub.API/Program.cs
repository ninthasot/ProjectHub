using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ProjectHub.API.ExceptionHandlers;
using ProjectHub.Modules.Identity.Infrastructure;
using ProjectHub.Modules.Workspaces.Infrastructure;
using Scalar.AspNetCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityModule(builder.Configuration);
builder.Services.AddWorkspaceModule(builder.Configuration);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => { });

builder.Services.AddAuthorization();

builder.Services
    .AddFastEndpoints(
        o => o.Assemblies =
        [typeof(ProjectHub.Modules.Identity.Api.IAssemblyReference).Assembly,
        typeof(ProjectHub.Modules.Workspaces.Api.IAssemblyReference).Assembly])
    .SwaggerDocument(o =>
    {
        o.DocumentSettings = s =>
        {
            s.DocumentName = "v1";
            s.Title = "ProjectHub API";
            s.Version = "v1";
        };
        o.MaxEndpointVersion = 1;
        o.ShortSchemaNames = true;
    });

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

// Add services to the container.

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseFastEndpoints(config =>
{
    config.Endpoints.RoutePrefix = "api";
    config.Serializer.Options.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
    config.Versioning.Prefix = "v";
});

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi(c => c.Path = "/openapi/{documentName}.json");
    app.MapScalarApiReference(o => o.AddDocument("v1"));
}

await app.RunAsync();
