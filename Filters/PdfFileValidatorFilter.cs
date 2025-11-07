using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging.Abstractions;
using Portfolio.Validators;

namespace Portfolio.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class PdfFileValidatorFilter(string fieldName, string[] allowedExtensions, long maxsize) : Attribute,IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var dtoObj = context.ActionArguments.Values.FirstOrDefault();
            if (dtoObj==null)
            {
                context.Result = new BadRequestObjectResult("invalid request data");
                return;
            }
            var dtoType = dtoObj.GetType();
            var propertyInfo=dtoType.GetProperty(fieldName);
            if (propertyInfo == null)
            {
                context.Result = new BadRequestObjectResult($"{fieldName} file not found in dto");
                return;
            }
            var file=propertyInfo.GetValue(dtoObj) as IFormFile;
            if(file==null)
            {
                context.Result = new BadRequestObjectResult($"{fieldName} file not found ");
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
