using Portfolio.Dto.RequestDto;

namespace Portfolio.Interfaces.IServices
{
    public interface ILandingPageDetailsService
    {
        /// <summary>
        /// to save landing page details
        /// </summary>
        /// <param name="landingPageDetailRequestDto"></param>
        /// <returns></returns>
        Task SaveLandingPageDetailsAsync(LandingPageDetailDto landingPageDetailRequestDto);
        /// <summary>
        /// to get landing page details
        /// </summary>
        /// <returns></returns>
        Task<LandingPageDetailDto> GetLandingPageDetailsAsync();
        /// <summary>
        /// to update the landing page details
        /// </summary>
        /// <param name="landingPageDetailRequestDto"></param>
        /// <returns></returns>
        Task UpdateLandingPageDetailsAsync(LandingPageDetailDto landingPageDetailRequestDto);
    }
}
