using Portfolio.Dto;
using Portfolio.Models;

namespace Portfolio.Interfaces.IServices
{
    public interface IProfileService
    {
        public Task<ProfileDetail> GetProfileDetailsAsync();
        public Task UpdateProfileDetailsAsync(ProfileRequestDto profileRequestDto, string email);
        public Task CreateProfileAsync(ProfileRequestDto profileRequestDto);
        public Task DeleteProfileAsync(string email);
    }
}
