using CarsService.Application.Interfaces.Public;
using CarsService.Application.Requests;
using CarsService.Application.Requests.Car;
using Microsoft.AspNetCore.Mvc;

namespace CarsService.API.Controllers
{
    [ApiController]
    [Route("/api/cars")]
    public class CarsController : Controller
    {
        private readonly ICarsService _carsService;

        public CarsController(ICarsService carsService)
        {
            _carsService = carsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPaginatedCarsAsync(
            [FromQuery] PaginationParams paginationParams,
            CancellationToken cancellationToken)
        {
            var response = await _carsService.GetPaginatedCarsAsync(
                paginationParams,
                cancellationToken);

            return Ok(response);
        }

        [HttpGet("{carId:guid}")]
        public async Task<IActionResult> GetCarByIdAsync(
            [FromRoute] Guid carId,
            CancellationToken cancellationToken)
        {
            var response = await _carsService.GetCarByIdAsync(
                carId,
                cancellationToken);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarAsync(
            [FromForm] CreateCarRequest createCarRequest,
            CancellationToken cancellationToken)
        {
            await _carsService.CreateCarAsync(
                createCarRequest,
                cancellationToken);

            return Created();
        }

        [HttpPut("{carId:guid}")]
        public async Task<IActionResult> UpdateCarAsync(
            [FromRoute] Guid carId,
            [FromForm] UpdateCarRequest updateCarRequest,
            CancellationToken cancellationToken)
        {
            await _carsService.UpdateCarAsync(
                carId,
                updateCarRequest,
                cancellationToken);

            return Ok();
        }

        [HttpDelete("{carId:guid}")]
        public async Task<IActionResult> DeleteCarAsync(
            [FromRoute] Guid carId,
            CancellationToken cancellationToken)
        {
            await _carsService.DeleteCarAsync(
                carId,
                cancellationToken);

            return NoContent();
        }
    }
}
