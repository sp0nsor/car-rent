namespace CarsService.Application.DTOs
{
    public record PaginatedResultDto<T>(
        ICollection<T> Items,
        int PageSize,
        int PageIndex,
        int TotalPages);
}
