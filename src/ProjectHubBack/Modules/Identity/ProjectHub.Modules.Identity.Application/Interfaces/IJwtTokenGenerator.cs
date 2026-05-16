using ProjectHub.Modules.Identity.Application.UseCases.Login;
using ProjectHub.Modules.Identity.Domain.Entities;

namespace ProjectHub.Modules.Identity.Application.Interfaces;

public interface IJwtTokenGenerator
{
    LoginUserResult GenerateToken(User user);
}
