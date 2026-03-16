namespace ProjectHub.Modules.Identity.Features.Register;

public class RegisterUserCommandHandler : CommandHandler<RegisterUserCommand, RegisterUserResponseDto>
{
    public override async Task<RegisterUserResponseDto> ExecuteAsync(RegisterUserCommand command, CancellationToken ct = default)
    {
        var response = new RegisterUserResponseDto();

        ThrowError(c => c.Request, "Non");

        await new RegisterUserEvent(response).PublishAsync(Mode.WaitForNone, ct);

        return response;
    }
}
