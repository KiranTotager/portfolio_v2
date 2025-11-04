using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Dto.RequestDto;
using Portfolio.Dto.ResponseDto;
using Portfolio.Filters;
using Portfolio.Interfaces.IServices;
using Portfolio.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.Runtime.CompilerServices;

namespace Portfolio.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "CMS")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("api/v{version:apiversion}/[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;
        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }
        [Authorize]
        [HttpPost("create-profile")]
        [SwaggerOperation("use this to create profile")]
        [SwaggerResponse(StatusCodes.Status200OK,"Profile created successfully",typeof(CommonResponse<Object>))]
        [ImageFileValidatorFilter("ProfileImage",new string[] { ".jpeg",".png",".jpg",".webp"},400,400,1024*1024)]
        [PdfFileValidatorFilter("ResumeFile",new string[] { ".pdf"},5*1024*1024)]
        public async Task<ActionResult<CommonResponse<Object>>> CreateProfileAsync([FromForm] ProfileRequestDto profileRequestDto)
        {
            await _profileService.CreateProfileAsync(profileRequestDto);
            return Ok(new CommonResponse<Object>(StatusCodes.Status200OK, "Profile created successfully"));
        }
        [Authorize]
        [HttpGet("get-profile-details")]
        [SwaggerOperation("use this to get profile details")]
        [SwaggerResponse(StatusCodes.Status200OK, "Profile details fetched successfully", typeof(CommonResponse<ProfileResponseDto>))]
        public async Task<ActionResult<Object>> GetProfileDetailsAsync()
        {
            return await _profileService.GetProfileDetailsAsync();
        }
    }
}
