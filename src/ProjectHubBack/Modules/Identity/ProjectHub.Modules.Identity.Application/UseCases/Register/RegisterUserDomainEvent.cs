namespace ProjectHub.Modules.Identity.Application.UseCases.Register;

public sealed record RegisterUserDomainEvent(Guid Response) : IEvent { }
