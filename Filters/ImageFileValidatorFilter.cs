using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Portfolio.Validators;

namespace Portfolio.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ImageFileValidatorFilter(string feildName ,string[] allowedExtensions,int height,int width,int size) :Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if(!context.ActionArguments.TryGetValue(feildName,out var fileObj)|| fileObj is not IFormFile file)
            {
                context.Result = new BadRequestObjectResult($"{feildName} file is not valid or missing");
                return;
            }
            if(!FileValidator.isFileExensionAllowed(file,allowedExtensions))
            {
                context.Result = new BadRequestObjectResult($"{feildName} is invalid file");
                return;
            }
            if (!FileValidator.isImageResolutionValid(file, width, height))
            {
                context.Result=new BadRequestObjectResult($"{feildName} does not meet the required resolution of {width}x{height}");
                return;
            }
            await next();
        }
    }
}
