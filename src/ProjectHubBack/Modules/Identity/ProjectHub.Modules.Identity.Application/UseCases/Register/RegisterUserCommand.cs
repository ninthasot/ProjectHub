namespace ProjectHub.Modules.Identity.Application.UseCases.Register;

public sealed record RegisterUserCommand(string Email, string Username, string Password, string DisplayName) : ICommand<Guid> { }
