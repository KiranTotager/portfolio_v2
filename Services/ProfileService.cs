using Portfolio.Dto.RequestDto;
using Portfolio.Dto.ResponseDto;
using Portfolio.Interfaces.IRepository_s;
using Portfolio.Interfaces.IServices;
using Portfolio.Models;

namespace Portfolio.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;
        private readonly ILogger<ProfileService> _logger;
        public ProfileService(IProfileRepository profileRepository,ILogger<ProfileService> logger)
        {
            _profileRepository = profileRepository;
            _logger = logger;
        }

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
            try
            {
               if(profileRequestDto.ProfileImage!=null)
               {
                    string FileName = $"{Guid.NewGuid()}_{profileRequestDto.ProfileImage.FileName}";
                    string ResumeFileName = $"{Guid.NewGuid()}_{profileRequestDto.ResumeFile.FileName}";
                    var ProfileImagePath = Path.Combine("wwwRoot", "ProfileImages", FileName);
                    var ResumeFilePath=Path.Combine("wwwRoot","ResumeFiles", ResumeFileName);
                    using (var stream = new FileStream(ProfileImagePath, FileMode.Create))
                    {
                        await profileRequestDto.ProfileImage.CopyToAsync(stream);
                    }
                    using(var stream=new FileStream(ResumeFilePath, FileMode.Create))
                    {
                        await profileRequestDto.ResumeFile.CopyToAsync(stream);
                    }
                    profileDetail.ProfilePicUrl="/ProfileImages/" + FileName;
                    profileDetail.ResumeUrl="/ResumeFiles/" + ResumeFileName;
                }

            }
            catch(Exception ex)
            {
                _logger.LogError($"Error in uploading files: {ex.Message}");
            }
            await _profileRepository.AddProfileAsync(profileDetail);
        }

        public async Task DeleteProfileAsync(string email)
        {
            // to be implemented
        }

        public async Task<ProfileResponseDto> GetProfileDetailsAsync()
        {
            ProfileDetail profileDetail= await _profileRepository.GetProfileDetailsAsync();
            return new ProfileResponseDto
            {
                ProfileHolderName=profileDetail.Name,
                ProfileHolderCurrentDesignation=profileDetail.CurrentDesignation,
                ProfileHolderEmail=profileDetail.Email,
                ProfileHolderPhoneNumber=profileDetail.PhoneNumber,
                ProfileHolderAvailabilityToWorkStatus=profileDetail.AvailabilityToWorkStatus,
                ProfileHolderShortDescription=profileDetail.ShortDescription,
                ProfileHolderLongDescription=profileDetail.LongDescription,
                ProfileHolderAddress=profileDetail.Address,
                ProfileImageUrl=profileDetail.ProfilePicUrl,
                ResumeFileUrl=profileDetail.ResumeUrl,
            };
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
