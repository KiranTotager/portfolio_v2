using Portfolio.Models;

namespace Portfolio.Interfaces.IRepository_s
{
    public interface IExperianceRepository
    {
        public Task AddExperianceAsync(Experiance experiance);
        public Task<IEnumerable<Experiance>> GetAllExperiancesAsync();
        public Task<Experiance> GetExperianceByIdAsync(int id);
        public Task<Experiance> UpdateExperianceAsync(Experiance experiance);
        public Task DeleteExperianceAsync(int id);
        public Task<int> GetExperiancesCountAsync();
    }
}
