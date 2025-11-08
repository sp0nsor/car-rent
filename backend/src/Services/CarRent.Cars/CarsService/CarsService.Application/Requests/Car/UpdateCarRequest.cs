using CarsService.Infrastructure.Enums;
using Microsoft.AspNetCore.Http;

namespace CarsService.Application.Requests.Car
{
    public record UpdateCarRequest(
        string Brand,
        string Model,
        CarType CarType,
        SteeringType SteeringType,
        int Capacity,
        int Gasoline,
        int ReleaseYear,
        ICollection<IFormFile>? Images);
}
