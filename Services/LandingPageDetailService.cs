using Portfolio.CustomExceptions;
using Portfolio.Dto.RequestDto;
using Portfolio.Interfaces.IRepository_s;
using Portfolio.Interfaces.IServices;
using Portfolio.Models;
using System.Reflection.Metadata.Ecma335;

namespace Portfolio.Services
{
    public class LandingPageDetailService : ILandingPageDetailsService
    {
        private readonly ILandingPageRepository _repository;
        public LandingPageDetailService(ILandingPageRepository repository)
        {
            _repository = repository;
        }
        public async Task<LandingPageDetailDto> GetLandingPageDetailsAsync()
        {
            LandingPageDetails LPageDetails= await _repository.GetLandingPageDetailsAsync();
            return new LandingPageDetailDto
            {
                HelloMessage = LPageDetails?.HelloMessage,
                PassionMessage = LPageDetails?.PassionMessage,
                ShortDescription = LPageDetails?.ShortDescription,
            };
        }

        public async Task SaveLandingPageDetailsAsync(LandingPageDetailDto landingPageDetailRequestDto)
        {
            await _repository.DeleteAllLandingPageDetailDetailsAsync();
            LandingPageDetails LPageDetail = new LandingPageDetails
            {
                HelloMessage = landingPageDetailRequestDto.HelloMessage,
                PassionMessage = landingPageDetailRequestDto.PassionMessage,
                ShortDescription = landingPageDetailRequestDto.ShortDescription,
            };
            await _repository.AddLandingPageDetailsAsync(LPageDetail);
        }

        public async Task UpdateLandingPageDetailsAsync(LandingPageDetailDto landingPageDetailRequestDto)
        {
            LandingPageDetails LPageDetails =await _repository.GetLandingPageDetailsAsync();
            if(LPageDetails==null)
            {
                throw new NotFoundException("landing page details");
            }
            LPageDetails.HelloMessage=landingPageDetailRequestDto.HelloMessage;
            LPageDetails.PassionMessage = landingPageDetailRequestDto.PassionMessage;
            LPageDetails.ShortDescription=landingPageDetailRequestDto.ShortDescription;
            await _repository.UpdateLandingPageDetailAsync(LPageDetails);
        }
    }
}
