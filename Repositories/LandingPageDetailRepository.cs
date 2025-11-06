using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Interfaces.IRepository_s;
using Portfolio.Models;

namespace Portfolio.Repositories
{
    public class LandingPageDetailRepository : ILandingPageRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<LandingPageDetails> _logger;
        public LandingPageDetailRepository(ApplicationDbContext applicationDbContext, ILogger<LandingPageDetails> logger)
        {
            _context = applicationDbContext;
            _logger = logger;
        }
        public async Task AddLandingPageDetailsAsync(LandingPageDetails landingPageDetails)
        {
            try
            {
                await _context.LandingPageDetails.AddAsync(landingPageDetails);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("error while adding the landing page details to database because "+ex.Message);
                throw;
            }
        }

        public async Task DeleteAllLandingPageDetailDetailsAsync()
        {
            try
            {
                await _context.Database.ExecuteSqlRawAsync("Truncate Table LandingPageDetails");
            }
            catch (Exception ex)
            {
                _logger.LogError("error while truncating the landing page detail table because " + ex.Message);
                throw;
            }
        }

        public async Task<LandingPageDetails> GetLandingPageDetailsAsync()
        {
            try
            {
                return await _context.LandingPageDetails.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("error while fetching the landing page details from the datase because " + ex.Message);
                throw;
            }
        }

        public async Task UpdateLandingPageDetailAsync(LandingPageDetails landingPageDetails)
        {
            try
            {
                _context.LandingPageDetails.Update(landingPageDetails);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("error while updating the landing page details to the datase because " + ex.Message);
                throw;
            }
        }
    }
}
