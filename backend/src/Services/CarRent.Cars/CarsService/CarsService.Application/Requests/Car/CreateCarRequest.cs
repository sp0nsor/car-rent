using CarsService.Infrastructure.Enums;
using Microsoft.AspNetCore.Http;

namespace CarsService.Application.Requests.Car
{
    public record CreateCarRequest(
        string Brand,
        string Model,
        CarType CarType,
        SteeringType SteeringType,
        int SeatsCount,
        int DrivingRange,
        int ReleaseYear,
        ICollection<IFormFile> Images);
}
