using Portfolio.Dto.RequestDto;
using Portfolio.Interfaces.IRepository_s;

namespace Portfolio.Interfaces.IServices
{
    public interface IContactMeService
    {
        /// <summary>
        /// to add contact request 
        /// </summary>
        /// <param name="contactUsRequestDto">dto to add to database</param>
        /// <returns></returns>
        Task AddContactRequestAsync(ContactUsRequestDto contactUsRequestDto);
    }
}
