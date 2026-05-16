namespace ProjectHub.Modules.Identity.Application.UseCases.Login;

public sealed record LoginUserResult(string AccessToken, DateTimeOffset ExpiresAt);
