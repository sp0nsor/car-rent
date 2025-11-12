namespace CarsService.Application.Requests.Post
{
    public record CreatePostRequest(
        Guid CarId,
        string Description,
        int DiscountPercentage,
        float PricePerDay);
}
