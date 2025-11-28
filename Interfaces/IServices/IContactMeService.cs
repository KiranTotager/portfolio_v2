using Portfolio.Dto.RequestDto;
using Portfolio.Dto.ResponseDto;
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
        /// <summary>
        /// Asynchronously retrieves all contact requests.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of  <see
        /// cref="ContactUsRequestDto"/> objects representing the contact requests. The list will be empty  if no
        /// contact requests are available.</returns>
        Task<List<ContactUsResponseDto>> GetAllContactRequestsAsync();
    }
}
