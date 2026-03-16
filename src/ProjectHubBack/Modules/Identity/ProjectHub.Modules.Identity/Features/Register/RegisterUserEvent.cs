namespace ProjectHub.Modules.Identity.Features.Register;

public sealed record RegisterUserEvent(RegisterUserResponseDto Response) : IEvent { }
