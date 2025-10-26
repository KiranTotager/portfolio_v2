using Portfolio.CustomExceptions;
using Portfolio.Dto.RequestDto;
using Portfolio.Dto.ResponseDto;
using Portfolio.Interfaces.IRepository_s;
using Portfolio.Interfaces.IServices;
using Portfolio.Models;

namespace Portfolio.Services
{
    public class AuthService : IAuthService
    {
        private readonly IApplicationUserRepository _applicationUserRepository;
        public AuthService(IApplicationUserRepository applicationUserRepository)
        {
            _applicationUserRepository = applicationUserRepository;
        }
        public Task<AuthResponseDto> GenerateRefreshTokenAsync(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthResponseDto> LoginAsync(LoginRequestDto loginRequestDto)
        {
            ApplicationUser AppUser=await _applicationUserRepository.GetApplicationUserByEmailAsync(loginRequestDto.EmailId);
            if (AppUser == null)
            {
                throw new NotFoundException($"user with the email {loginRequestDto.EmailId}");
            }
            return new AuthResponseDto
            {
                AuthToken = "",
                RefreshToken = ""
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
                Role=applicationUserRequestDto.Role
            };
            await _applicationUserRepository.AddApplicationUserAsync(NewAppUser);
        }

        
    }
}
