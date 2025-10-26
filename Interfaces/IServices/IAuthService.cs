using Portfolio.Dto.RequestDto;
using Portfolio.Dto.ResponseDto;

namespace Portfolio.Interfaces.IServices
{
    public interface IAuthService
    {
        public Task RegisterAsync(ApplicationUserRequestDto applicationUserRequestDto);
        public Task<AuthResponseDto> LoginAsync(LoginRequestDto loginRequestDto);
        public Task<AuthResponseDto> GenerateRefreshTokenAsync(string refreshToken);
    }
}
