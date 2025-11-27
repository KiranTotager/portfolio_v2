using Portfolio.Dto.RequestDto;

namespace Portfolio.Interfaces.IServices
{
    public interface IMailService
    {
        /// <summary>
        /// method to send email
        /// </summary>
        /// <param name="contactUsRequestDto"></param>
        /// <returns></returns>
        Task SendMailToAdminAsync(ContactUsRequestDto contactUsRequestDto);
        /// <summary>
        /// mail sender helper
        /// </summary>
        /// <param name="to"></param>
        /// <param name="body"></param>
        /// <param name="subject"></param>
        /// <returns></returns>
        Task MailSenderHelperAsync(string to, string body, string subject);
    }
}
