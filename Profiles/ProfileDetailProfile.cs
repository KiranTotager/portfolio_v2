using AutoMapper;
using Portfolio.Dto.RequestDto;
using Portfolio.Dto.ResponseDto;
using Portfolio.Models;

namespace Portfolio.Profiles
{
    public class ProfileDetailProfile : Profile
    {
        public ProfileDetailProfile()
        {
            CreateMap<ProfileDetail, ProfileRequestDto>();
            CreateMap<ProfileResponseDto, ProfileDetail>();
        }
    }
}
