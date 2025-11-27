using Portfolio.Interfaces.IRepository_s;
using Portfolio.Interfaces.IServices;
using Portfolio.Interfaces.IUtils;
using Portfolio.Repositories;
using Portfolio.Services;
using Portfolio.Utils;

namespace Portfolio.Extensions
{
    public static class RegistrationExtensions
    {
        public static IServiceCollection AddRegistrationsSetUp(this IServiceCollection services)
        {
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<ILandingPageRepository, LandingPageDetailRepository>();
            services.AddScoped<ILandingPageDetailsService, LandingPageDetailService>();
            services.AddScoped<IContactMeService, ContactMeService>();
            services.AddScoped<IContactMeRepository, ContactMeRepository>();
            services.AddScoped<IMailService, MailService>();
            return services;
        }
    }
}
