using CarsService.Infrastructure.Enums;
using Microsoft.AspNetCore.Http;

namespace CarsService.Application.Requests.Car
{
    public record UpdateCarRequest(
        string Brand,
        string Model,
        string Color,
        CarType CarType,
        TransmissionType TransmissionType,
        int SeatsCount,
        int DrivingRange,
        int ReleaseYear,
        int Power,
        ICollection<IFormFile>? Images);
}
