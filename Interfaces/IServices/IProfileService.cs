using Portfolio.Dto.RequestDto;
using Portfolio.Dto.ResponseDto;
using Portfolio.Models;

namespace Portfolio.Interfaces.IServices
{
    public interface IProfileService
    {
        /// <summary>
        /// to get profile details
        /// </summary>
        /// <returns></returns>
        public Task<ProfileResponseDto> GetProfileDetailsAsync();
        /// <summary>
        /// to update the profile details
        /// </summary>
        /// <param name="profileRequestDto"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task UpdateProfileDetailsAsync(ProfileRequestDto profileRequestDto, string email);
        /// <summary>
        /// to add profile data
        /// </summary>
        /// <param name="profileRequestDto"></param>
        /// <returns></returns>
        public Task CreateProfileAsync(ProfileRequestDto profileRequestDto);
        /// <summary>
        /// to delete profile data
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task DeleteProfileAsync(string email);
    }
}
