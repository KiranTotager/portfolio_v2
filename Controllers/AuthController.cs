using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Dto.RequestDto;
using Portfolio.Dto.ResponseDto;
using Portfolio.Interfaces.IServices;
using Swashbuckle.AspNetCore.Annotations;

namespace Portfolio.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName ="Authentication")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Route("api/v{version:apiVersion}/[Controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        [SwaggerOperation("use this end call to login ")]
        public async Task<ActionResult<AuthResponseDto>> LoginAsync([FromBody] LoginRequestDto loginRequestDto)
        {
            return await _authService.LoginAsync(loginRequestDto);
        }
        [HttpPost("renew-auth-token")]
        [SwaggerOperation("use this end point to get renewed refresh token")]
        public async Task<ActionResult<AuthResponseDto>> RenewAuthTokenAsync([FromBody] string refreshToken)
        {
            return await _authService.GenerateRefreshTokenAsync(refreshToken);
        }
        [Authorize]
        [HttpPost("create-application-user")]
        [SwaggerOperation("use this end point to create the app user")]
        public async Task<ActionResult<CommonResponse<Object>>> CreateAppUserAsync([FromBody] ApplicationUserRequestDto applicationUserRequestDto)
        {
            await _authService.RegisterAsync(applicationUserRequestDto);
            return Ok(new CommonResponse<Object>(StatusCodes.Status201Created,"application user created successfully"));
        }
    }
}
