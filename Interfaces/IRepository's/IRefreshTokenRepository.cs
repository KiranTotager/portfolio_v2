using Portfolio.Models;

namespace Portfolio.Interfaces.IRepository_s
{
    public interface IRefreshTokenRepository
    {
        public Task AddRefreshTokenAsync(RefreshToken refreshToken);
        public Task RemoveRefreshTokenAsync(string refreshToken);
        public Task<RefreshToken> GetRefreshTokenAsync(string refreshToken);
        public Task UpdateRefreshTOkenAsync(RefreshToken refreshToken,string Token);
    }
}
