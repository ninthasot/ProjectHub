namespace ProjectHub.Modules.Identity.Application.UseCases.Login;

public sealed record LoginUserCommand(string Username, string Password) : ICommand<LoginUserResult> { }