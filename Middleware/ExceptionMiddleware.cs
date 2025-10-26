using Microsoft.AspNetCore.Diagnostics;
using Portfolio.CustomExceptions;

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
                            case NotFoundException notFoundException:
                                statusCode = StatusCodes.Status404NotFound;
                                message=notFoundException.Message;
                                break;
                            case DuplicateException duplicateException:
                                statusCode = StatusCodes.Status409Conflict;
                                message=duplicateException.Message;
                                break;
                        }
                    }

                });
            });
            return app;
        }
    }
}
