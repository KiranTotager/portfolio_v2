using MongoDB.Driver;
using Portfolio.Data;
using Portfolio.Interfaces.IRepository_s;
using Portfolio.Models;

namespace Portfolio.Repositories
{

    public class ProfileRepository : IProfileRepository
    {
        private readonly ILogger<ProfileRepository> _logger;
        private readonly IMongoCollection<ProfileDetail> _profileCollection;
        public ProfileRepository(ILogger<ProfileRepository> logger, MongoDbContext context)
        {
            _logger = logger;
            _profileCollection=context.GetCollecgtion<ProfileDetail>("ProfileDetails");

        }
        public async Task AddProfileAsync(ProfileDetail profileDetail)
        {
            try
            {
                await _profileCollection.InsertOneAsync(profileDetail);
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
                return await _profileCollection.Find(profile => profile.Email == emailId).FirstOrDefaultAsync();
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
                return await _profileCollection.Find(_ => true).FirstOrDefaultAsync();
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
                await _profileCollection.ReplaceOneAsync(p => p.Email == email, profileDetail);
            }
            catch (Exception ex)
        {
                _logger.LogError($"Error updating profile details: {ex.Message}");
                throw;
            }
        }
               
    }
}
