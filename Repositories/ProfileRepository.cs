using Portfolio.Data;
using Portfolio.Interfaces.IRepository_s;
using Portfolio.Models;

namespace Portfolio.Repositories
{

    public class ProfileRepository : IProfileRepository
    {
        private readonly ILogger<ProfileRepository> _logger;
        public ProfileRepository(ILogger<ProfileRepository> logger)
        {
            _logger = logger;

        }
        public async Task AddProfileAsync(ProfileDetail profileDetail)
        {
            try
            {
            }catch(Exception ex)
            {
                _logger.LogError($"Error adding profile: {ex.Message}");
                throw;
            }
        }

        public async Task<ProfileDetail> GetProfileDetailByEmailIdAsync(string emailId)
        {
            try
            {
                return null;
            }catch(Exception ex)
            {
                _logger.LogError($"Error retrieving profile details: {ex.Message}");
                throw;
            }
        }

        public async Task<ProfileDetail> GetProfileDetailsAsync()
        {
            try
            {
                return null;
            }
            catch (Exception ex)
        {
                _logger.LogError($"Error retrieving profile details: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateProfileDetailsAsync(ProfileDetail profileDetail, string email)
        {
            try
            {
                profileDetail.UpdatedAt = DateTime.Now;
            }
            catch (Exception ex)
        {
                _logger.LogError($"Error updating profile details: {ex.Message}");
                throw;
            }
        }
               
    }
}
