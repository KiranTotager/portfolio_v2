using Portfolio.Dto.RequestDto;
using Portfolio.Dto.ResponseDto;

namespace Portfolio.Interfaces.IServices
{
    public interface IAuthService
    {
        /// <summary>
        /// Registers a new application user asynchronously.
        /// </summary>
        /// <remarks>This method performs the registration of a new user based on the provided details. 
        /// Ensure that all required fields in the <paramref name="applicationUserRequestDto"/>  are populated before
        /// calling this method.</remarks>
        /// <param name="applicationUserRequestDto">The data transfer object containing the details of the user to be registered.  This parameter cannot be <see
        /// langword="null"/>.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public Task RegisterAsync(ApplicationUserRequestDto applicationUserRequestDto);
        /// <summary>
        /// Authenticates a user based on the provided login credentials.
        /// </summary>
        /// <param name="loginRequestDto">An object containing the user's login credentials, such as username and password.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an  <see
        /// cref="AuthResponseDto"/> object with authentication details, such as a token  and user information, if the
        /// login is successful.</returns>
        public Task<AuthResponseDto> LoginAsync(LoginRequestDto loginRequestDto);
        /// <summary>
        /// to generate refresh token
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        public Task<AuthResponseDto> GenerateRefreshTokenAsync(string refreshToken);
    }
}
