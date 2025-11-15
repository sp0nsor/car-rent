namespace CarsService.Application.DTOs.Car
{
    public record CarDto(
        Guid Id,
        string Model,
        string Brand,
        string Color,
        string CarType,
        string TransmissionType,
        int SeatsCount,
        int DrivingRange,
        int ReleaseYear,
        int Power,
        ICollection<string> Images);
}
