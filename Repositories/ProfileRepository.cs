using Portfolio.Interfaces.IRepository_s;
using Portfolio.Models;

namespace Portfolio.Repositories
{

    public class ProfileRepository : IProfileRepository
    {
        private readonly ILogger<ProfileRepository> _logger;
        private readonly IConfiguration _configuration;
        public ProfileRepository(ILogger<ProfileRepository> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public Task AddProfileAsync(ProfileDetail profileDetail)
        {
            throw new NotImplementedException();
        }

        public Task<ProfileDetail> GetProfileDetailsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProfileDetail> UpdateProfileDetailsAsync(ProfileDetail profileDetail)
        {
            throw new NotImplementedException();
        }
    }
}
