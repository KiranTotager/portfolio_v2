using Portfolio.Dto.RequestDto;
using Portfolio.Models;

namespace Portfolio.Interfaces.IUtils
{
    public interface ITokenService
    {
        public string GenerateAuthToken(ApplicationUser applicationUser);
        public string GenerateRefreshToken();
    }
}
