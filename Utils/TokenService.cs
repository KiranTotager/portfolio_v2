using Microsoft.IdentityModel.Tokens;
using Portfolio.Dto.RequestDto;
using Portfolio.Interfaces.IUtils;
using Portfolio.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Portfolio.Utils
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<TokenService> _logger;
        public TokenService(IConfiguration configuration, ILogger<TokenService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public string GenerateAuthToken(ApplicationUser applicationUser)
        {
            //var Role = applicationUser.Role;
            int ExpiryTime = _configuration.GetValue<int>("Jwt:AuthTokenExpiryTime");
            var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("Jwt:SecretKey")));
            var Credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,applicationUser.Id),
                //new Claim(ClaimTypes.Role,applicationUser.Role.ToString()),
            };
            var Token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                signingCredentials: Credentials,
                claims: userClaims,
                expires: DateTime.Now.AddMinutes(ExpiryTime)
                );
            return new JwtSecurityTokenHandler().WriteToken(Token);
        }

        public string GenerateRefreshToken()
        {
            var RandomNumber=new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(RandomNumber);
                return Convert.ToBase64String(RandomNumber);
            }
        }
    }
}
