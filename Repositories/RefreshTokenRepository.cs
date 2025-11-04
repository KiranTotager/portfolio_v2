using Portfolio.Data;
using Portfolio.Interfaces.IRepository_s;
using Portfolio.Models;

namespace Portfolio.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly ILogger<RefreshTokenRepository> _logger;
        public RefreshTokenRepository(MongoDbContext context, ILogger<RefreshTokenRepository> logger)
        {
            _logger = logger;
        }
        public async Task AddRefreshTokenAsync(RefreshToken refreshToken)
        {
            try
            {
            }
            catch (Exception ex)
            {
                _logger.LogError("error while inserting the refresh token" + ex.Message);
                throw;
            }
        }

        public async Task<RefreshToken> GetRefreshTokenAsync(string refreshToken)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError("error while getting the refresh token, reason: "+ex.Message);
                throw;
            }
        }

        public async Task RemoveRefreshTokenAsync(string refreshToken)
        {
            try
            {
            }
            catch (Exception ex)
            {
                _logger.LogError("error while deleting the refresh token, reason is: ", ex.Message);
                throw;
            }
        }

        public async Task UpdateRefreshTOkenAsync(RefreshToken refreshToken, string Token)
        {
            try
            {
            }
            catch (Exception ex)
            {
                _logger.LogError("error while updating the token");
                throw;
            }
        }
    }
}
