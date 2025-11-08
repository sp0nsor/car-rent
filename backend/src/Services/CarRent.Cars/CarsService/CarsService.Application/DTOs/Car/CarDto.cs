namespace CarsService.Application.DTOs.Car
{
    public record CarDto(
        Guid Id,
        string Model,
        string Brand,
        string CarType,
        string Steering,
        int Capacity,
        int Gasoline,
        int ReleaseYear,
        ICollection<string> Images);
}
