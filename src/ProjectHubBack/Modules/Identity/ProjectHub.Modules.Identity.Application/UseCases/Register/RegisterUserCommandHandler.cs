namespace ProjectHub.Modules.Identity.Application.UseCases.Register;

public class RegisterUserCommandHandler : CommandHandler<RegisterUserCommand, Guid>
{
    public override async Task<Guid> ExecuteAsync(RegisterUserCommand command, CancellationToken ct = default)
    {
        var response = Guid.NewGuid();

        ThrowError(c => c.email, "Non");

        await new RegisterUserDomainEvent(response).PublishAsync(Mode.WaitForNone, ct);

        return response;
    }
}
