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
    [Route("/api/v{apiVerson:apiversion}/[controller]/")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public class LandingPageDetailController : ControllerBase
    {
        private readonly ILandingPageDetailsService _landingPageDetailsService;
        public LandingPageDetailController(ILandingPageDetailsService landingPageDetailsService)
        {
            _landingPageDetailsService = landingPageDetailsService;
        }
        [ApiExplorerSettings(GroupName ="Client")]
        [SwaggerOperation("use this end calls to get the landing page detail")]
        [HttpGet("get-landing-page-details")]
        public async Task<ActionResult<LandingPageDetailDto>> GetLandingPageDetailsAsync()
        {
            return Ok(await _landingPageDetailsService.GetLandingPageDetailsAsync());
        }
        [ApiExplorerSettings(GroupName = "CMS")]
        [HttpPost("add-landing-page-detail")]
        [SwaggerOperation("use this end call to add the landing page details")]
        public async Task<ActionResult<CommonResponse<Object>>> AddLandingPageDetailsAsync([FromBody] LandingPageDetailDto landingPageDetailDto)
        {
            await _landingPageDetailsService.SaveLandingPageDetailsAsync(landingPageDetailDto);
            return Ok(new CommonResponse<Object>(StatusCodes.Status201Created, "Landing Page detail added successfully"));
        }
        [ApiExplorerSettings(GroupName = "CMS")]
        [HttpPatch("update-landing-page-details")]
        [SwaggerOperation("use this end call to update the landing page details")]
        public async Task<ActionResult<CommonResponse<Object>>> UpdateLandingPageDetailsAsync([FromBody] LandingPageDetailDto landingPageDetailDto)
        {
            await _landingPageDetailsService.UpdateLandingPageDetailsAsync(landingPageDetailDto);
            return Ok(new CommonResponse<Object>(StatusCodes.Status201Created, "landng page detail update successfully"));
        }
    }
}
