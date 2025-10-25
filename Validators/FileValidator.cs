using Microsoft.AspNetCore.Routing.Constraints;
using System.Drawing;

namespace Portfolio.Validators
{
    public class FileValidator
    {
        public static bool isFileExensionAllowed(IFormFile file,List<string> allowedExtensios)
        {
            var extension=Path.GetExtension(file.FileName).ToLowerInvariant();
            return allowedExtensios.Contains(extension);
        }
        public static bool isFileSizeWithinLimit(IFormFile file,long maxFileSizeInBytes)
        {
            return file.Length <= maxFileSizeInBytes;
        }
        public static bool isImageResolutionValid(IFormFile file,int Width,int Height)
        {
            using (var image = Image.FromStream(file.OpenReadStream()))
            {
                return image.Width == Width && image.Height == Height;
            }
        }
    }
}
