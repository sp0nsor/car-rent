using CarsService.Application.Exceptions;
using CarsService.Application.Interfaces.Internal;
using Microsoft.AspNetCore.Http;

namespace CarsService.Application.Services.Internal
{
    public class ImageService : IImageService
    {
        private static readonly string[] _allowedExtensions =
        {
            ".jpg",
            ".jpeg",
            ".png"
        };

        private static long _maxFileSize = 5 * 1024 * 1024; // 5 MB

        private readonly static string _staticFilePath =
            Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles");

        public async Task<string> WriteImageAsync(
            IFormFile image,
            CancellationToken cancellationToken)
        {
            var fileExtensions = Path.GetExtension(image.FileName).ToLowerInvariant();

            if (!_allowedExtensions.Contains(fileExtensions))
            {
                throw new BadRequestExecption("Unsupported image format");
            }

            if (!Directory.Exists(_staticFilePath))
            {
                Directory.CreateDirectory(_staticFilePath);
            }

            var fileName = Guid.NewGuid().ToString() + fileExtensions;
            var fullPath = Path.Combine(_staticFilePath, fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await image.CopyToAsync(stream, cancellationToken);
            }

            return fullPath;
        }

        public async Task DeleteImageAsync(
            string imagePath,
            CancellationToken cancellationToken)
        {
            if (!File.Exists(imagePath))
            {
                throw new BadRequestExecption("Invalid image path");
            }

            await Task.Run(() => File.Delete(imagePath));
        }
    }
}
