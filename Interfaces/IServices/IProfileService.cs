using Portfolio.Models;

namespace Portfolio.Interfaces.IServices
{
    public interface IProfileService
    {
        public Task<ProfileDetail> GetProfileDetailsAsync();
        public Task UpdateProfileDetailsAsync(ProfileDetail profileDetail, string email);
        public Task CreateProfileAsync(ProfileDetail profileDetail);
    }
}
