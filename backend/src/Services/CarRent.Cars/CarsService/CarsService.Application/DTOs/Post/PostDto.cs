using CarsService.Application.DTOs.Car;

namespace CarsService.Application.DTOs.Post
{
    public record PostDto(
        Guid Id,
        Guid CarId,
        CarDto? Car,
        string Description,
        int? DiscountPercentage,
        float AverageRating,
        float PricePerDay,
        DateTime UpdatedAt);
}
