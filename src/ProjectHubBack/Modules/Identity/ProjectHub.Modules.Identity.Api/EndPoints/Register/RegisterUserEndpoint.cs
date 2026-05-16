using ProjectHub.Modules.Identity.Application.UseCases.Register;

namespace ProjectHub.Modules.Identity.Api.EndPoints.Register;

public class RegisterUserEndpoint : Endpoint<RegisterUserRequest, RegisterUserResponse>
{
    public override void Configure()
    {
        Post("/users");
        AllowAnonymous();
        Summary(s =>
        {
            s.Summary = "Create a new user";
            s.Description = "Creates a new user in the system";
        });
        Options(b => b.Produces<RegisterUserResponse>());
    }

    public override async Task HandleAsync(RegisterUserRequest req, CancellationToken ct)
    {
        var command = new RegisterUserCommand(req.Email, req.Username, req.Password, req.DisplayName);

        Guid id = await command.ExecuteAsync(ct);

        RegisterUserResponse response = new() { Id = id };

        await Send.CreatedAtAsync("GetUserById", new { id }, responseBody: response, cancellation: ct);
    }
}
