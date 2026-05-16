using ProjectHub.Shared.Abstractions.Domain;

namespace ProjectHub.Modules.Identity.Domain.Entities;

public sealed class User : AggregateRoot
{
    public string Email { get; private set; } = string.Empty;
    public string Username { get; private set; } = string.Empty;
    public string DisplayName { get; private set; } = string.Empty;
    public string PasswordHash { get; private set; } = string.Empty;
    public DateTimeOffset CreatedAt { get; private init; }
    public DateTimeOffset? UpdatedAt { get; private set; }

    public static User Create(
        string email,
        string username,
        string passwordHash,
        string displayName) => new()
    {
        Id = Guid.NewGuid(),
        Email = email,
        Username = username,
        PasswordHash = passwordHash,
        DisplayName = displayName,
        CreatedAt = DateTimeOffset.UtcNow
    };

    public void UpdateProfile(
        string email,
        string displayName)
    {
        Email = email;
        DisplayName = displayName;
        UpdatedAt = DateTimeOffset.UtcNow;
    }
}
