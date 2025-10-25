using Portfolio.Dto.RequestDto;
using Portfolio.Dto.ResponseDto;
using Portfolio.Models;

namespace Portfolio.Interfaces.IServices
{
    public interface IProfileService
    {
        public Task<ProfileResponseDto> GetProfileDetailsAsync();
        public Task UpdateProfileDetailsAsync(ProfileRequestDto profileRequestDto, string email);
        public Task CreateProfileAsync(ProfileRequestDto profileRequestDto);
        public Task DeleteProfileAsync(string email);
    }
}
