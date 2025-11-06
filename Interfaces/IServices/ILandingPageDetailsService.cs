using Portfolio.Dto.RequestDto;

namespace Portfolio.Interfaces.IServices
{
    public interface ILandingPageDetailsService
    {
        Task SaveLandingPageDetailsAsync(LandingPageDetailDto landingPageDetailRequestDto);
        Task<LandingPageDetailDto> GetLandingPageDetailsAsync();
        Task UpdateLandingPageDetailsAsync(LandingPageDetailDto landingPageDetailRequestDto);
    }
}
