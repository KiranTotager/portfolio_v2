using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Portfolio.Validators;

namespace Portfolio.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ImageFileValidatorFilter(string feildName, string[] allowedExtensions, int height, int width, int size) : Attribute, IAsyncActionFilter
    {

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var dtoObj = context.ActionArguments.Values.FirstOrDefault();
            if (dtoObj == null)
            {
                context.Result = new BadRequestObjectResult("Invalid request data");
                return;
            }
            var dtoType = dtoObj.GetType();
            var propertyInfo = dtoType.GetProperty(feildName);
            if (propertyInfo == null)
            {
                context.Result = new BadRequestObjectResult($"{feildName} file not found in dto");
                return;
            }
            var file= propertyInfo.GetValue(dtoObj) as IFormFile;
            if (file == null)
            {
                context.Result = new BadRequestObjectResult($"{feildName} file not found ");
                return;
            }
            if (!FileValidator.isFileExensionAllowed(file, allowedExtensions))
            {
                context.Result = new BadRequestObjectResult($"{feildName} is invalid file");
                return;
            }
            if (!FileValidator.isImageResolutionValid(file, width, height))
            {
                context.Result = new BadRequestObjectResult($"{feildName} does not meet the required resolution of {width}x{height}");
                return;
            }
            await next();
        }
    }
}
