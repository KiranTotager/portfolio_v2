using AutoMapper;
using Portfolio.Dto.RequestDto;
using Portfolio.Dto.ResponseDto;
using Portfolio.Models;

namespace Portfolio.Profiles
{
    public class ContactUsProfile : Profile
    {
        public ContactUsProfile()
        {
            CreateMap<ContactUsRequestDto, ContactMe>();
            CreateMap<ContactMe, ContactUsResponseDto>();
        }
    }
}
