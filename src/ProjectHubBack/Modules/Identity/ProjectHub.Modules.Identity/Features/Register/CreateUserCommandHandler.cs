namespace ProjectHub.Modules.Identity.Features.Register;

public class CreateUserCommandHandler : CommandHandler<CreateUserCommand, RegisterUserResponseDto>
{
    public override async Task<RegisterUserResponseDto> ExecuteAsync(CreateUserCommand command, CancellationToken ct = default)
    {
        var response = new RegisterUserResponseDto();
        ThrowError(c => c.Request, "Non");

        return response;
    }
}
