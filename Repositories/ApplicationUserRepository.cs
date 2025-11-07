using Microsoft.EntityFrameworkCore;
using Portfolio.CustomExceptions;
using Portfolio.Data;
using Portfolio.Interfaces.IRepository_s;
using Portfolio.Models;

namespace Portfolio.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly ILogger<ApplicationUserRepository> _logger;
        private readonly ApplicationDbContext _context;
        public ApplicationUserRepository(ILogger<ApplicationUserRepository> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task AddApplicationUserAsync(ApplicationUser applicationUser)
        {
            try
            {
                await _context.AddAsync(applicationUser);
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

        public async Task<List<ApplicationUser>> GetAllApplicationUsersAsync()
        {
            try
            {
                //return await _context.Users.ToListAsync();
                return null;
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
                return null;
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
            }
            catch(Exception ex)
            {
                _logger.LogError("error while updating user data", ex);
                throw;
            }
        }
    }
}
