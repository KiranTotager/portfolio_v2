using Portfolio.Models;

namespace Portfolio.Interfaces.IRepository_s
{
    public interface IHireMeRequestsRepository
    {
        //public Task AddHireMeRequestAsync(HireMeRequest hireMeRequest);
        //public Task<IEnumerable<HireMeRequest>> GetAllHireMeRequestsAsync();
        //public Task<HireMeRequest> GetHireMeRequestByIdAsync(int id);
        public Task DeleteHireMeRequestAsync(int id);
        public Task<int> GetHireMeRequestsCountAsync();
    }
}
