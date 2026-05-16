namespace ProjectHub.Modules.Identity.Api.EndPoints.Login;

public sealed record LoginUserRequest
{
    public string Username { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}
