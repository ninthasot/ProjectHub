
using ProjectHub.Modules.Identity.Domain.Interfaces;

namespace ProjectHub.Modules.Identity.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    public Task<Guid> AddAsync(User user, CancellationToken ct) => throw new NotImplementedException();
    public Task DeleteAsync(User user, CancellationToken ct) => throw new NotImplementedException();
    public Task<bool> ExistsAsync(string email, CancellationToken ct) => throw new NotImplementedException();
    public Task<User?> GetByEmailAsync(string email, CancellationToken ct) => throw new NotImplementedException();
    public Task<User?> GetByIdAsync(Guid id, CancellationToken ct) => throw new NotImplementedException();
    public Task UpdateProfileAsync(User user, CancellationToken ct) => throw new NotImplementedException();
}
