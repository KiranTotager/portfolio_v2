using Microsoft.OpenApi.Models;

namespace Portfolio.Extensions
{
    public static class SwaggerExtesnion
    {
        public static IServiceCollection AddSwaggerSetUp(this IServiceCollection service)
        {
            service.AddSwaggerGen(options =>
            {
                options.EnableAnnotations();
                options.SwaggerDoc("CMS", new OpenApiInfo
                {
                    Title = "Portfolio CMS",
                    Version = "v1",
                    Description = "use this end points for handeling the content of the websites"
                });
                options.SwaggerDoc("Authentication", new OpenApiInfo
                {
                    Title = "Portfolio Authentication",
                    Version = "v1",
                    Description = "use this end points for handeling the authentication of the websites"
                });
                options.SwaggerDoc("Client", new OpenApiInfo
                {
                    Title = "Cleint api's",
                    Version = "v1",
                    Description = "use this end call to get details for clients"
                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.ApiKey,
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Scheme = "bearer",

                    Description = "Jwt authorization using bearer scheme"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference=new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
        Array.Empty<string>()
        },
    });
            });
            return service;
        }

        public static IApplicationBuilder UseSwaggerSetUp(this IApplicationBuilder app)
        {
            app.UseSwagger(c =>
            {
                c.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi2_0;
            }
       );
            app.UseSwaggerUI(
                c =>
                {
                    c.SwaggerEndpoint("/swagger/CMS/swagger.json", "CMS");
                    c.SwaggerEndpoint("/swagger/Authentication/swagger.json", "Authentication");
                    c.SwaggerEndpoint("/swagger/Client/swagger.json", "Client");
                    c.InjectStylesheet("/SwaggerCustom/SwaggerCustom.css");
                    c.InjectJavascript("/SwaggerCustom/SwaggerCustom.js");
                }
                );
            return app;
        }
    }
}
