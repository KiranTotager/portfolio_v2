using Portfolio.CustomExceptions;
using Portfolio.Dto.RequestDto;
using Portfolio.Dto.ResponseDto;
using Portfolio.Interfaces.IRepository_s;
using Portfolio.Interfaces.IServices;
using Portfolio.Interfaces.IUtils;
using Portfolio.Models;

namespace Portfolio.Services
{
    public class AuthService : IAuthService
    {
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenService;
        public AuthService(IApplicationUserRepository applicationUserRepository, ITokenService tokenService,IRefreshTokenRepository refreshTokenRepository, IConfiguration configuration)
        {
            _applicationUserRepository = applicationUserRepository;
            _tokenService = tokenService;
            _refreshTokenRepository = refreshTokenRepository;
            _configuration = configuration;
        }
        public Task<AuthResponseDto> GenerateRefreshTokenAsync(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthResponseDto> LoginAsync(LoginRequestDto loginRequestDto)
        {
            ApplicationUser AppUser = await _applicationUserRepository.GetApplicationUserByEmailAsync(loginRequestDto.EmailId);
            if (AppUser == null)
            {
                throw new NotFoundException($"user with the email {loginRequestDto.EmailId}");
            }
            else if (!BCrypt.Net.BCrypt.Verify(loginRequestDto.Password, AppUser.HashedPassword))
            {
                throw new UnauthorizedAccessException("incorrect password");
            }
            int RefTokenExpiryTime = _configuration.GetValue<int>("Jwt:RefreshTokenExpiryTime");
            string AuthenticationToken = _tokenService.GenerateAuthToken(AppUser);
            string RefToken = _tokenService.GenerateRefreshToken();
            _refreshTokenRepository.AddRefreshTokenAsync(new RefreshToken
            {
                Token = AuthenticationToken,
                UserId = AppUser.Id,
            });
            return new AuthResponseDto
                {
                    AuthToken =AuthenticationToken,
                    RefreshToken =RefToken 
                };
        }

        public async Task RegisterAsync(ApplicationUserRequestDto applicationUserRequestDto)
        {
            ApplicationUser AppUser = await _applicationUserRepository.GetApplicationUserByEmailAsync(applicationUserRequestDto.EmailID);
            if (AppUser != null)
            {
                throw new DuplicateException($"user with email {applicationUserRequestDto.EmailID}");
            }
            ApplicationUser NewAppUser = new ApplicationUser
            {
                EmailId = applicationUserRequestDto.EmailID,
                UserName = applicationUserRequestDto.UserName,
                HashedPassword = BCrypt.Net.BCrypt.HashPassword(applicationUserRequestDto.Password),
                Role = applicationUserRequestDto.Role
            };
            await _applicationUserRepository.AddApplicationUserAsync(NewAppUser);
        }


    }
}
