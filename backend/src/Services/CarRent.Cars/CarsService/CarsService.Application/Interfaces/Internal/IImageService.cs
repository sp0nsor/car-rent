using Microsoft.AspNetCore.Http;

namespace CarsService.Application.Interfaces.Internal
{
    public interface IImageService
    {
        Task<string> WriteImageAsync(IFormFile image, CancellationToken cancellationToken);
        Task DeleteImageAsync(string imagePath, CancellationToken cancellationToken);
    }
}