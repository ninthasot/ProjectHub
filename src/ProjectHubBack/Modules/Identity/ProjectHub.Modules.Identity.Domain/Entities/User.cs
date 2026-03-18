using ProjectHub.Shared.Abstractions.Domain;

namespace ProjectHub.Modules.Identity.Domain.Entities;

public sealed class User : AggregateRoot
{
    public string Email { get; private set; } = string.Empty;
    public string PasswordHash { get; private set; } = string.Empty;
    public string DisplayName { get; private set; } = string.Empty;
    public DateTimeOffset CreatedAt { get; private init; }

    //Used by EF Core
    private User() { }

    public static User Create(string email, string passwordHash, string displayName) => new()
    {
        Id = Guid.NewGuid(),
        Email = email,
        PasswordHash = passwordHash,
        DisplayName = displayName,
        CreatedAt = DateTimeOffset.UtcNow
    };
}
