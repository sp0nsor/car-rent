namespace CarsService.Application.DTOs.Car
{
    public record CarDto(
        Guid Id,
        string Model,
        string Brand,
        string CarType,
        string Steering,
        int SeatsCount,
        int DrivingRange,
        int ReleaseYear,
        ICollection<string> Images);
}
