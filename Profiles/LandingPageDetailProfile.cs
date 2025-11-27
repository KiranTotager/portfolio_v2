using AutoMapper;
using Portfolio.Dto.RequestDto;
using Portfolio.Models;

namespace Portfolio.Profiles
{
    public class LandingPageDetailProfile : Profile
    {
        public LandingPageDetailProfile()
        {
            CreateMap<LandingPageDetails, LandingPageDetailDto>();
            CreateMap<LandingPageDetailDto, LandingPageDetails>();
        }
    }
}
