using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Dto.RequestDto;
using Portfolio.Dto.ResponseDto;
using Portfolio.Interfaces.IServices;
using Swashbuckle.AspNetCore.Annotations;

namespace Portfolio.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("/api/v{version:apiVersion}/")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    
    public class ContactMeConroller : ControllerBase
    {
        private readonly IContactMeService contactMeService;
        private readonly IMailService mailService;
        public ContactMeConroller(IContactMeService contactMeService,IMailService mailService)
        {
            this.contactMeService = contactMeService;
            this.mailService = mailService;
        }

        [ApiExplorerSettings(GroupName = "Client")]
        [HttpPost("contact-me")]
        [SwaggerOperation("use this end call to add contact me reuests")]
        public async Task<ActionResult<CommonResponse<Object>>> AddContactRequestAsync([FromBody] ContactUsRequestDto contactUsRequestDto)
        {
            await contactMeService.AddContactRequestAsync(contactUsRequestDto);
            await mailService.SendMailToAdminAsync(contactUsRequestDto);
            return Ok(new CommonResponse<Object>(StatusCodes.Status201Created, "contact us created successfully"));
        }

        [ApiExplorerSettings(GroupName = "CMS")]
        [HttpGet("contact-me-requests")]
        [SwaggerOperation("use this end call to get all contact me reuests")]
        public async Task<ActionResult<List<ContactUsResponseDto>>> GetAllContactRequestsAsync()
        {
            return await contactMeService.GetAllContactRequestsAsync();
        }
    }
}
