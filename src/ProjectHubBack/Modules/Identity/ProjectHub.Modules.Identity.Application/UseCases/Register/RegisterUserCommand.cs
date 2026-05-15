namespace ProjectHub.Modules.Identity.Application.UseCases.Register;

public sealed record RegisterUserCommand(string username, string email, string password) : ICommand<Guid> { }
