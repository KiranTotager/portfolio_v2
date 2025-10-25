using Portfolio.Dto;
using Portfolio.Interfaces.IRepository_s;
using Portfolio.Interfaces.IServices;
using Portfolio.Models;

namespace Portfolio.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;

        public async Task CreateProfileAsync(ProfileRequestDto profileRequestDto)
        {
            ProfileDetail profileDetail = new ProfileDetail
            {
                Name = profileRequestDto.ProfileHolderName,
                CurrentDesignation=profileRequestDto.ProfileHolderCurrentDesignation,
                Email = profileRequestDto.ProfileHolderEmail,
                PhoneNumber = profileRequestDto.ProfileHolderPhoneNumber,
                AvailabilityToWorkStatus=profileRequestDto.ProfileHolderAvailabilityToWorkStatus,
                ResumeUrl="",
                ProfilePicUrl="",
                ShortDescription=profileRequestDto.ProfileHolderShortDescription,
                LongDescription=profileRequestDto.ProfileHolderLongDescription,
                UpdatedAt=DateTime.Now,
                Address=profileRequestDto.ProfileHolderAddress,
            };
            await _profileRepository.AddProfileAsync(profileDetail);
        }

        public async Task DeleteProfileAsync(string email)
        {
            // to be implemented
        }

        public async Task<ProfileDetail> GetProfileDetailsAsync()
        {
            return await _profileRepository.GetProfileDetailsAsync();
        }

        public async Task UpdateProfileDetailsAsync(ProfileRequestDto profileRequestDto, string email)
        {
            ProfileDetail profileDetail=await _profileRepository.GetProfileDetailByEmailIdAsync(email);
            profileDetail.Name = profileRequestDto.ProfileHolderName;
            profileDetail.CurrentDesignation = profileRequestDto.ProfileHolderCurrentDesignation;
            profileDetail.Email = profileRequestDto.ProfileHolderEmail;
            profileDetail.PhoneNumber = profileRequestDto.ProfileHolderPhoneNumber;
            profileDetail.AvailabilityToWorkStatus = profileRequestDto.ProfileHolderAvailabilityToWorkStatus;
            profileDetail.ResumeUrl = "";
            profileDetail.ProfilePicUrl = "";
            profileDetail.ShortDescription = profileRequestDto.ProfileHolderShortDescription;
            profileDetail.LongDescription = profileRequestDto.ProfileHolderLongDescription;
            profileDetail.UpdatedAt = DateTime.Now;
            profileDetail.Address = profileRequestDto.ProfileHolderAddress;
            await _profileRepository.UpdateProfileDetailsAsync(profileDetail, email);
        }
    }
}
