namespace ProjectHub.Modules.Identity.Features.Register;

public sealed record RegisterUserCommand(RegisterUserRequestDto Request) : ICommand<RegisterUserResponseDto> { }
