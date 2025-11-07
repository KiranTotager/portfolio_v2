using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;
        public AuthService(IApplicationUserRepository applicationUserRepository, ITokenService tokenService,IRefreshTokenRepository refreshTokenRepository, IConfiguration configuration,UserManager<ApplicationUser> userManager)
        {
            _applicationUserRepository = applicationUserRepository;
            _tokenService = tokenService;
            _refreshTokenRepository = refreshTokenRepository;
            _configuration = configuration;
            _userManager = userManager;
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
            //else if (!BCrypt.Net.BCrypt.Verify(loginRequestDto.Password, AppUser.HashedPassword))
            //{
            //    throw new UnauthorizedAccessException("incorrect password");
            //}
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
                Email = applicationUserRequestDto.EmailID,
                UserName = applicationUserRequestDto.UserName,
            };
            await _userManager.CreateAsync(NewAppUser, applicationUserRequestDto.Password);
            await _userManager.AddToRoleAsync(NewAppUser, applicationUserRequestDto.Role.ToString());

        }


    }
}
