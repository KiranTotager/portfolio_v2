using Portfolio.Enums;
using Swashbuckle.AspNetCore.Annotations;

namespace Portfolio.Dto.ResponseDto
{
    public class ApplicationUserResponseDto
    {
        [SwaggerSchema(Description = "unique identifier of the user")]
        public string Id { get; set; }
        [SwaggerSchema(Description = "username of the user")]
        public string UserName { get; set; }
        [SwaggerSchema(Description = "email identifier of the user")]
        public string EmailId { get; set; }
        [SwaggerSchema(Description = "role of the user")]
        public ApplicationUserRoles Role { get; set; }
    }
}
