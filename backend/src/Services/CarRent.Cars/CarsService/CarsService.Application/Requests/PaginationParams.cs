namespace CarsService.Application.Requests
{
    public record PaginationParams(
        int PageIndex,
        int PageSize);
}
