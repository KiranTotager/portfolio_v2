
using Asp.Versioning;

namespace Portfolio.Extensions
{
    public static class ApiVersioningExtension
    {
        public static IServiceCollection AddApiVersioningSetUp(this IServiceCollection service)
        {
            service.AddEndpointsApiExplorer();
            service.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            }
                ).AddMvc()
                .AddApiExplorer(
                options =>
                {
                    options.GroupNameFormat = "'v'VVV";
                    options.SubstituteApiVersionInUrl = true;
                });
            return service;
        }
    }
}
