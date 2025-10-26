using Microsoft.IdentityModel.Tokens;
using Portfolio.Dto.RequestDto;
using Portfolio.Interfaces.IUtils;
using Portfolio.Models;
using System.Security.Cryptography;
using System.Text;

namespace Portfolio.Utils
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<TokenService> _logger;
        public string GenerateAuthToken(ApplicationUser applicationUser)
        {
            var Role = applicationUser.Role;
            int ExpiryTime = _configuration.GetValue<int>("Jwt:AuthTokenExpiryTime");
            var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("Jwt:SecretKey")));
            var Credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);
            throw new NotImplementedException();
        }

        public string GenerateRefreshToken()
        {
            throw new NotImplementedException();
        }
    }
}
