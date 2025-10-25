using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Portfolio.Validators;

namespace Portfolio.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class PdfFileValidatorFilter(string fieldName, string[] allowedExtensions, long maxsize) : Attribute,IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ActionArguments.TryGetValue(fieldName, out var fileObj) || fileObj is not IFormFile file)
            {
                context.Result = new BadRequestObjectResult($"File {fieldName} is missing or invalid ");
                return;
            }

            if (!FileValidator.isFileExensionAllowed(file, allowedExtensions))
            {
                context.Result = new BadRequestObjectResult($"{fieldName} is invalid file");
                return;
            }
            if (!FileValidator.isFileSizeWithinLimit(file, maxsize))
            {
                context.Result = new BadRequestObjectResult($"{fieldName} exceeds the maximum allowed size of {maxsize} bytes");
                return;
            }
            await next();
        }

    }
}
