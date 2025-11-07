using Microsoft.AspNetCore.Diagnostics;
using Portfolio.CustomExceptions;
using Portfolio.Dto.ResponseDto;
using System.Text.Json;

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
                                message = notFoundException.Message;
                                break;
                            case DuplicateException duplicateException:
                                statusCode = StatusCodes.Status409Conflict;
                                message = duplicateException.Message;
                                break;
                            case UnauthorizedAccessException unauthorizedAccessException:
                                statusCode = StatusCodes.Status401Unauthorized;
                                message = unauthorizedAccessException.Message;
                                break;
                        }
                        context.Response.StatusCode = statusCode;
                        await context.Response.WriteAsync(JsonSerializer.Serialize(new CommonResponse<Object>(statusCode, message)));
                    }

                });
            });
            return app;
        }
    }
}
