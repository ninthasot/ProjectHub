namespace ProjectHub.Modules.Identity.Api.EndPoints.Login;

public sealed record LoginUserResponse(string AccessToken, DateTimeOffset ExpiresAt);
