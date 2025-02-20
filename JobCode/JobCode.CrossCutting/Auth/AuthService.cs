using JobCode.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JobCode.CrossCutting.Auth;

public class AuthService(IConfiguration _configuration) : IAuthService
{
    public string GenerateToken(string email, string role)
    {
        var issuer = _configuration["Jwt:Issuer"] ?? throw new InvalidOperationException("Issuer não configurado");
        var audience = _configuration["Jwt:Audience"] ?? throw new InvalidOperationException("Audience não configurado");
        var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? throw new InvalidOperationException("Chave JWT não configurada"));

        #pragma warning disable S6781
        var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
        #pragma warning restore S6781

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
            Issuer = issuer,
            Audience = audience,
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

