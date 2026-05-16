using ProjectHub.Modules.Identity.Domain.Entities;

namespace ProjectHub.Modules.Identity.Application.UseCases.Login;

public class LoginUserCommandHandler(
    IUserRepository userRepository,
    IPasswordHasher passwordHasher,
    IJwtTokenGenerator jwtTokenGenerator) : CommandHandler<LoginUserCommand, LoginUserResult>
{
    public async override Task<LoginUserResult> ExecuteAsync(LoginUserCommand command, CancellationToken ct = default)
    {
        User? user = await userRepository.GetByUsernameAsync(command.Username, ct);

        if (user is null)
        {

            ThrowError(x => x.Username, "Invalid username or password");
        }

        bool isPasswordValid = passwordHasher.Verify(user!.PasswordHash, command.Password);

        if (!isPasswordValid)
        {

            ThrowError(x => x.Password, "Invalid username or password");
        }

        return jwtTokenGenerator.GenerateToken(user!);
    }
}
