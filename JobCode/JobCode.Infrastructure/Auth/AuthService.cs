using JobCode.Core.Services;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using JobCode.Core.Entities;

namespace JobCode.Infrastructure.Auth;

public class AuthService : IAuthService
{
    private readonly JwtSettings _Jwt;
    public AuthService(JwtSettings jwt)
    {
        _Jwt = jwt;
    }

    public string GenerateToken(string email, string role)
    {
        var credentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Jwt.Key)), SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
                new Claim("username", email),
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = _Jwt.Issuer,
            Audience = _Jwt.Audience,
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddHours(2),
            NotBefore = DateTime.UtcNow.AddMinutes(-1),
            SigningCredentials = credentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}

