using System.ComponentModel.DataAnnotations;

namespace ProjectHub.Modules.Identity.Infrastructure.Settings;

internal sealed class JwtSettings
{
    public const string SectionName = "JwtSettings";
    [Required, MinLength(32)]
    public required string SecretKey { get; init; }
    public required string Issuer { get; init; }
    public required string Audience { get; init; }
    public int ExpiryInMinutes { get; init; }
}