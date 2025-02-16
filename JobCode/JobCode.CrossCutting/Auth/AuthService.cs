using JobCode.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JobCode.CrossCutting.Auth
{
    public class AuthService: IAuthService
    {
        private readonly IConfiguration _configuration;
        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;     
        }

        public string GenerateToken(string email, string role)
        {
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = _configuration["Jwt:Key"]
                    ?? throw new ArgumentException("A chave JWT não está configurada corretamente.");


            var jwtKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            var credentials = new SigningCredentials(jwtKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                 new Claim("username", email),
                 new Claim(JwtRegisteredClaimNames.Sub, email),
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                 new Claim(ClaimTypes.Role, role)
            };

            
            var expireDate = DateTime.Now.AddHours(2);
            var notBefore = DateTime.Now.AddMinutes(-1);

            var token = new JwtSecurityToken(issuer,audience,claims, notBefore, expireDate, credentials);

            var tokenGenerated = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenGenerated;
        }
    }
}
