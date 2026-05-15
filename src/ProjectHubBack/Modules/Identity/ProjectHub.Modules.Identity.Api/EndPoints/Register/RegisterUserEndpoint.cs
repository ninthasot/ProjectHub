using ProjectHub.Modules.Identity.Application.UseCases.Register;

namespace ProjectHub.Modules.Identity.Api.EndPoints.Register;

public class RegisterUserEndpoint : Endpoint<RegisterUserRequestDto, Guid>
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
        var command = new RegisterUserCommand(req.Username, req.Email, req.Password);

        Guid response = await command.ExecuteAsync(ct);

        await Send.CreatedAtAsync("GetUserById", new { id = response }, responseBody: response, cancellation: ct);
    }
}
