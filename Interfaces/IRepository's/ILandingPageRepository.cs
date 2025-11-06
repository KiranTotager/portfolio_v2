using Portfolio.Models;

namespace Portfolio.Interfaces.IRepository_s
{
    public interface ILandingPageRepository
    {
        Task AddLandingPageDetailsAsync(LandingPageDetails landingPageDetails);
        Task UpdateLandingPageDetailAsync(LandingPageDetails landingPageDetails);
        Task<LandingPageDetails> GetLandingPageDetailsAsync();
        Task DeleteAllLandingPageDetailDetailsAsync();
    }
}
