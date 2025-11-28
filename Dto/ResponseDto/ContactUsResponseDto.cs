using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Dto.ResponseDto
{
    public class ContactUsResponseDto
    {
        /// <summary>
        /// Gets or sets the name associated with the object.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the email address associated with the user.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the phone number associated with the user.
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Gets or sets the message associated with the current operation or context.
        /// </summary>
        public string Message { get; set; }

    }
}
