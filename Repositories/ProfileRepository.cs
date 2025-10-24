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
           await _profileCollection.InsertOneAsync(profileDetail);
        }

        public async Task<ProfileDetail> GetProfileDetailsAsync()
        {
            return await _profileCollection.Find(_ => true).FirstOrDefaultAsync();
        }

        public async Task UpdateProfileDetailsAsync(ProfileDetail profileDetail,string email)
        {
            profileDetail.ResumeUpdatedAt=DateTime.Now;
            await _profileCollection.ReplaceOneAsync(p => p.Email==email,profileDetail);
        }
        
    }
}
