using Microsoft.Extensions.Options;
using Portfolio.Config;
using Portfolio.Dto.RequestDto;
using Portfolio.Interfaces.IServices;
using Portfolio.Models;
using System.Net;
using System.Net.Mail;

namespace Portfolio.Services
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        private readonly ILogger<MailService> _logger;
        public MailService(IOptions<MailSettings> options, ILogger<MailService> logger)
        {
            _mailSettings = options.Value;
            _logger = logger;
        }

        public async Task MailSenderHelperAsync(string to, string body, string subject)
        {
            try
            {
                SmtpClient client = new SmtpClient(_mailSettings.Host, _mailSettings.Port);
                client.Credentials = new NetworkCredential(_mailSettings.From, _mailSettings.PassKey);
                client.EnableSsl = _mailSettings.EnableSSL;
                MailMessage message = new MailMessage();
                message.From = new MailAddress(_mailSettings.From);
                message.Body = body;
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.To.Add(to);
                await client.SendMailAsync(message);
                
            }
            catch (Exception ex)
            {
                _logger.LogError("error while sending email to admin because" + ex.Message);
            }
        }

        public async Task SendMailToAdminAsync(ContactUsRequestDto contactUsRequestDto)
        {
            string subject = "contact us request";
            string body = $@"<html>
                  <body>
                    <p>Dear Admin,</p>
                    <p>A new contact request has been submitted from the website. The details are as follows:</p>
                
                    <p><b>Name:</b> {contactUsRequestDto.Name}</p>
                    <p><b>Email:</b> {contactUsRequestDto.Email}</p>
                    <p><b>Phone number:</b> {contactUsRequestDto.PhoneNumber}</p>
                    <p><b>Message:</b></p>
                    <p>{contactUsRequestDto.Message}</p>
                
                    <br/>
                
                    <br/>
                    <p>Best Regards,</p>
                    <p><b>best regards mysself.</b></p>
                  </body>
                </html>
                ";
            await MailSenderHelperAsync(_mailSettings.AdminMail, body, subject);
        }


    }
}
