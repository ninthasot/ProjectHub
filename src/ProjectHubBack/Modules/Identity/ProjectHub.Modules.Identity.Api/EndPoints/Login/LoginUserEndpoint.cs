using ProjectHub.Modules.Identity.Application.UseCases.Login;

namespace ProjectHub.Modules.Identity.Api.EndPoints.Login;

public class LoginUserEndpoint : Endpoint<LoginUserRequest, LoginUserResponse>
{
    public override void Configure()
    {
        Post("/login");
        AllowAnonymous();
        Version(1);
        Summary(s =>
        {
            s.Summary = "Login a user";
            s.Description = "Authenticates a user in the system";
        });
    }

    public override async Task HandleAsync(LoginUserRequest req, CancellationToken ct)
    {
        var command = new LoginUserCommand(req.Username, req.Password);

        LoginUserResult result = await command.ExecuteAsync(ct);

        LoginUserResponse response = new(result.AccessToken, result.ExpiresAt);

        await Send.OkAsync(response, ct);
    }
}