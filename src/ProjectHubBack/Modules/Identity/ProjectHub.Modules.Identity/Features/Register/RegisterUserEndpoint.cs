namespace ProjectHub.Modules.Identity.Features.Register;

public class RegisterUserEndpoint : Endpoint<RegisterUserRequestDto, RegisterUserResponseDto>
{
    public override void Configure()
    {
        Post("/users");
        Summary(s =>
        {
            s.Summary = "Create a new user";
            s.Description = "Creates a new user in the system";
        });
        Options(b => b.Produces<RegisterUserResponseDto>());
    }

    public override async Task HandleAsync(RegisterUserRequestDto req, CancellationToken ct)
    {
        var command = new CreateUserCommand(req);

        RegisterUserResponseDto response = await command.ExecuteAsync(ct);

        await Send.CreatedAtAsync("GetUserById", new { id = response.Id }, responseBody: response, cancellation: ct);
    }
}
