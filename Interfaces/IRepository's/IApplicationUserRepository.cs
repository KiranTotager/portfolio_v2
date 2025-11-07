using Portfolio.Models;

namespace Portfolio.Interfaces.IRepository_s
{
    public interface IApplicationUserRepository
    {
        public Task AddApplicationUserAsync(ApplicationUser applicationUser);
        public Task<ApplicationUser> GetApplicationUserByEmailAsync(string email);
        public Task<List<ApplicationUser>> GetAllApplicationUsersAsync();
        public Task UpdateApplicationUserAsync(ApplicationUser applicationUser, string email);
        public Task DeleteApplicationUserAsync(string email);
    }
}
