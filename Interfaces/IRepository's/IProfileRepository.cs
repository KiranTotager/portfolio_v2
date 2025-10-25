using Portfolio.Models;

namespace Portfolio.Interfaces.IRepository_s
{
    public interface IProfileRepository
    {
        public Task<ProfileDetail> GetProfileDetailsAsync();
        public Task UpdateProfileDetailsAsync(ProfileDetail profileDetail,string email);
        public Task AddProfileAsync(ProfileDetail profileDetail);
        public Task<ProfileDetail> GetProfileDetailByEmailIdAsync(string emailId);
    }
}
