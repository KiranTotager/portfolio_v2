using AutoMapper;
using Portfolio.Dto.RequestDto;
using Portfolio.Interfaces.IRepository_s;
using Portfolio.Interfaces.IServices;
using Portfolio.Models;

namespace Portfolio.Services
{
    public class ContactMeService : IContactMeService
    {
        private readonly IContactMeRepository _contactMeRepository;
        private readonly IMapper _mapper;
        public ContactMeService(IContactMeRepository contactMeRepository,IMapper mapper)
        {
            _contactMeRepository = contactMeRepository;
            _mapper = mapper;
        }
        public async Task AddContactRequestAsync(ContactUsRequestDto contactUsRequestDto)
        {
            ContactMe NewContact = _mapper.Map<ContactMe>(contactUsRequestDto);
            await _contactMeRepository.AddContactMeAsync(NewContact);
        }
    }
}
