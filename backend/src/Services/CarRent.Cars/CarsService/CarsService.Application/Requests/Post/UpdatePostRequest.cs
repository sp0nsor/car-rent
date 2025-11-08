namespace CarsService.Application.Requests.Post
{
    public record UpdatePostRequest(
        string Description,
        int DiscountPercentage,
        float PricePerDay);
}
