using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectHub.Modules.Identity.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; private set; } = string.Empty;
    public string PasswordHash { get; private set; } = string.Empty;
    public string DisplayName { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private init; } = DateTime.UtcNow;

}
