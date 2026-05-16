using ProjectHub.Modules.Identity.Infrastructure.Migrations;

namespace ProjectHub.Modules.Identity.Infrastructure.Persistence.Repositories;

public class UserRepository(IdentityDbContext context) : IUserRepository
{
    public async Task<Guid> AddAsync(User user, CancellationToken ct)
    {
        await context.Users.AddAsync(user, ct);
        await context.SaveChangesAsync(ct);
        return user.Id;
    }

    public async Task<bool> ExistsByEmailAsync(string email, CancellationToken ct)
    {
        bool exists = await context.Users.AnyAsync(u => u.Email == email, ct);
        return exists;
    }

    public async Task<bool> ExistsByUsernameAsync(string username, CancellationToken ct)
    {
        bool exists = await context.Users.AnyAsync(u => u.Username == username, ct);
        return exists;
    }

    public async Task<User?> GetByUsernameAsync(string username, CancellationToken ct)
    {
        User? user = await context.Users.FirstOrDefaultAsync(u => u.Username == username, ct);
        return user;
    }
}
