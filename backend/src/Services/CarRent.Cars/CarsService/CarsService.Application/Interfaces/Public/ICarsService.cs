using CarsService.Application.DTOs;
using CarsService.Application.DTOs.Car;
using CarsService.Application.Requests;
using CarsService.Application.Requests.Car;

namespace CarsService.Application.Interfaces.Public
{
    public interface ICarsService
    {
        Task<PaginatedResultDto<CarDto>> GetPaginatedCarsAsync(PaginationParams paginationParams, CancellationToken cancellationToken);
        Task<CarDto> GetCarByIdAsync(Guid carId, CancellationToken cancellationToken);
        Task CreateCarAsync(CreateCarRequest createCarRequest, CancellationToken cancellationToken);
        Task UpdateCarAsync(Guid carId, UpdateCarRequest updateCarRequest, CancellationToken cancellationToken);
        Task DeleteCarAsync(Guid carId, CancellationToken cancellationToken);
    }
}