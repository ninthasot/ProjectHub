using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Scalar.AspNetCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://your-identity-provider.com"; // Replace with your identity provider
        options.Audience = "your-api-audience"; // Replace with your API audience
        
        // For development/testing only - remove in production
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true
        };
    });

builder.Services.AddAuthorization();

builder.Services
    .AddFastEndpoints(o => o.Assemblies = 
        [typeof(ProjectHub.Modules.Identity.IAssemblyReference).Assembly,
        typeof(ProjectHub.Modules.Workspaces.IAssemblyReference).Assembly
    ])
    .SwaggerDocument();

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
});

if(app.Environment.IsDevelopment())
{
    app.UseOpenApi(c => c.Path = "/openapi/{documentName}.json");
    app.MapScalarApiReference(o => o.AddDocument("v1"));
}

await app.RunAsync();
