namespace ProjectHub.Modules.Identity.Api.EndPoints.Register;

public record RegisterUserRequestDto
{
    public required string Email { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string DisplayName { get; set; }

}
