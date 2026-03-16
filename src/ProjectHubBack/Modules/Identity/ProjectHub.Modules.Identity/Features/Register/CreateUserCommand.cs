namespace ProjectHub.Modules.Identity.Features.Register;

public sealed record CreateUserCommand(RegisterUserRequestDto Request) : ICommand<RegisterUserResponseDto> { }
