using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Interfaces.IRepository_s;
using Portfolio.Models;

namespace Portfolio.Repositories
{
    public class ContactMeRepository : IContactMeRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ContactMeRepository> _logger;
        public ContactMeRepository(ApplicationDbContext context, ILogger<ContactMeRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task AddContactMeAsync(ContactMe contactUs)
        {
            try
            {
                await _context.ContactMes.AddAsync(contactUs);
                await _context.SaveChangesAsync();   
            }
            catch (Exception ex)
            {
                _logger.LogError("error while storing the contact us detail in database");
                throw;
            }
        }

        public Task DeleteContactMeAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ContactMe>> GetAllContactMeAsync()
        {
            return await _context.ContactMes.ToListAsync();
        }

        public Task<ContactMe> GetContactMeByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetContactMeCountAsync()
        {
            throw new NotImplementedException();
        }
    }
}
