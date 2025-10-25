using Microsoft.AspNetCore.Diagnostics;

namespace Portfolio.Middleware
{
    public static class ExceptionMiddleware
    {
        public static IApplicationBuilder UseExceptionMiddleWare(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(error =>
            {
                error.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var ExceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (ExceptionFeature != null)
                    {
                        int statusCode = (int)StatusCodes.Status500InternalServerError;
                        string message = "Internal Server Error";
                        switch (ExceptionFeature.Error)
                        {

                        }
                    }

                });
            });
            return app;
        }
    }
}
