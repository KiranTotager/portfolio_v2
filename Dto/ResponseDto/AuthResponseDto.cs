using Swashbuckle.AspNetCore.Annotations;

namespace Portfolio.Dto.ResponseDto
{
    public class AuthResponseDto
    {
        [SwaggerSchema(Description = "authentication token for the user")]
        public string AuthToken { get; set; }
        [SwaggerSchema(Description = "refresh token for the user")]
        public string RefreshToken { get; set; }
    }
}
