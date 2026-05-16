using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProjectHub.Modules.Identity.Application.UseCases.Login;
using ProjectHub.Modules.Identity.Infrastructure.Settings;

namespace ProjectHub.Modules.Identity.Infrastructure.Security;

internal sealed class JwtTokenGenerator(IOptions<JwtSettings> jwtSettings) : IJwtTokenGenerator
{
    private readonly JwtSettings _settings = jwtSettings.Value;

    public LoginUserResult GenerateToken(User user)
    {
        DateTimeOffset expiresAt = DateTimeOffset.UtcNow.AddMinutes(_settings.ExpiryInMinutes);

        Claim[] claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("username", user.Username),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _settings.Issuer,
            audience: _settings.Audience,
            claims: claims,
            expires: expiresAt.UtcDateTime,
            signingCredentials: credentials
        );

        string accessToken = new JwtSecurityTokenHandler().WriteToken(token);

        return new LoginUserResult(accessToken, expiresAt);
    }
}
