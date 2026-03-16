namespace ProjectHub.Modules.Identity.Features.Register;

public sealed record RegisterUserDomainEvent(RegisterUserResponseDto Response) : IEvent { }
