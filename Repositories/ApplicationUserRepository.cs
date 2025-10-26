using MongoDB.Driver;
using Portfolio.CustomExceptions;
using Portfolio.Data;
using Portfolio.Interfaces.IRepository_s;
using Portfolio.Models;

namespace Portfolio.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly ILogger<ApplicationUserRepository> _logger;
        private readonly IMongoCollection<ApplicationUser> _users;
        public ApplicationUserRepository(ILogger<ApplicationUserRepository> logger,MongoDbContext context)
        {
            _logger = logger;
            _users=context.GetCollecgtion<ApplicationUser>("ApplicationUsers");
        }
        public async Task AddApplicationUserAsync(ApplicationUser applicationUser)
        {
            try
            {
                await _users.InsertOneAsync(applicationUser);
            }
            catch (Exception ex)
            {
                _logger.LogError("error while storing the user data", ex);
                throw;
            }
        }

        public Task DeleteApplicationUserAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<List<ApplicationUser>> GetAllApplicationUsersAsync()
        {
            try
            {
                return _users.Find(_ => true).ToListAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError("error while retrieving all user data", ex);
                throw;
            }
        }

        public async Task<ApplicationUser> GetApplicationUserByEmailAsync(string email)
        {
            try
            {
                return await _users.Find(user=>user.EmailId==email).FirstOrDefaultAsync() ?? throw new NotFoundException($"user with email id {email}");
            }
            catch(Exception ex)
            {
                _logger.LogError("error while retrieving user data by email", ex);
                throw;
            }
        }

        public async Task UpdateApplicationUserAsync(ApplicationUser applicationUser, string email)
        {
            try
            {
                await _users.ReplaceOneAsync(user => user.EmailId == email, applicationUser);
            }
            catch(Exception ex)
            {
                _logger.LogError("error while updating user data", ex);
                throw;
            }
        }
    }
}
