using ProjectHub.Modules.Identity.Domain.Entities;

namespace ProjectHub.Modules.Identity.Application.Interfaces;

public interface IUserRepository
{
    Task<Guid> AddAsync(User user, CancellationToken ct);
    Task<bool> ExistsByEmailAsync(string email, CancellationToken ct);
    Task<bool> ExistsByUsernameAsync(string username, CancellationToken ct);
}
