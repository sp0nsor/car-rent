namespace CarsService.Application.Requests.Post
{
    public record PostFilter(
        string? CarBrand,
        string? CarModel);
}
