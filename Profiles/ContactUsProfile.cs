using AutoMapper;
using Portfolio.Dto.RequestDto;
using Portfolio.Models;

namespace Portfolio.Profiles
{
    public class ContactUsProfile : Profile
    {
        public ContactUsProfile()
        {
            CreateMap<ContactMe, ContactUsRequestDto>();
            CreateMap<ContactUsRequestDto, ContactMe>();
        }
    }
}
