using ProjectHub.Modules.Identity.Domain.Entities;

namespace ProjectHub.Modules.Identity.Application.UseCases.Register;

public class RegisterUserCommandHandler(
    IPasswordHasher passwordHasher,
    IUserRepository userRepository) : CommandHandler<RegisterUserCommand, Guid>
{
    public override async Task<Guid> ExecuteAsync(RegisterUserCommand command, CancellationToken ct = default)
    {
        bool existsByEmail = await userRepository.ExistsByEmailAsync(command.Email, ct);
        bool existsByUsername = await userRepository.ExistsByUsernameAsync(command.Username, ct);

        if (existsByEmail)
        {
            AddError(u => u.Email, "Email is already in use.");
        }

        if (existsByUsername)
        {
            AddError(u => u.Username, "Username is already in use.");
        }

        ThrowIfAnyErrors();

        string passwordHash = passwordHasher.Hash(command.Password);

        var user = User.Create(
            command.Email,
            command.Username,
            passwordHash,
            command.DisplayName);

        return await userRepository.AddAsync(user, ct);
    }
}
