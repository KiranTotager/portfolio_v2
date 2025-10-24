using Portfolio.Models;

namespace Portfolio.Interfaces.IRepository_s
{
    public interface IProfileRepository
    {
        public Task<ProfileDetail> GetProfileDetailsAsync();
        public Task<ProfileDetail> UpdateProfileDetailsAsync(ProfileDetail profileDetail);
        public Task AddProfileAsync(ProfileDetail profileDetail);

    }
}
