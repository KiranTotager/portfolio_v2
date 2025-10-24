using Portfolio.Models;

namespace Portfolio.Interfaces.IRepository_s
{
    public interface IContactMeRepository
    {
        public Task AddContactMeAsync(ContactMe contactUs);
        public Task<IEnumerable<ContactMe>> GetAllContactMeAsync();
        public Task<ContactMe> GetContactMeByIdAsync(long id);
        public Task DeleteContactMeAsync(long id);
        public Task<int> GetContactMeCountAsync();

    }
}
