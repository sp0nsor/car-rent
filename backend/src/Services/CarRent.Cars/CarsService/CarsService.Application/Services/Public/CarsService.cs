using AutoMapper;
using CarsService.Application.DTOs;
using CarsService.Application.DTOs.Car;
using CarsService.Application.Exceptions;
using CarsService.Application.Interfaces.Internal;
using CarsService.Application.Interfaces.Public;
using CarsService.Application.Requests;
using CarsService.Application.Requests.Car;
using CarsService.Infrastructure.Entities;
using CarsService.Infrastructure.Interfaces;
using CarsService.Infrastructure.Specifications.Car;

namespace CarsService.Application.Services.Public
{
    public class CarsService : ICarsService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CarEntity> _carsRepository;
        private readonly IImageService _imageService;

        public CarsService(
            IMapper mapper,
            IRepository<CarEntity> carsRepository,
            IImageService imageService)
        {
            _mapper = mapper;
            _carsRepository = carsRepository;
            _imageService = imageService;
        }

        public async Task<PaginatedResultDto<CarDto>> GetPaginatedCarsAsync(
            PaginationParams paginationParams,
            CancellationToken cancellationToken)
        {
            var specification = new GetAllCarsSpecification();
            var (carEntities, totalPages) = await _carsRepository.GetAsync(
                specification,
                paginationParams.PageIndex,
                paginationParams.PageSize,
                cancellationToken);

            return new PaginatedResultDto<CarDto>(
                _mapper.Map<ICollection<CarDto>>(carEntities),
                paginationParams.PageSize,
                paginationParams.PageIndex,
                totalPages);
        }

        public async Task<CarDto> GetCarByIdAsync(
            Guid carId,
            CancellationToken cancellationToken)
        {
            var specification = new GetCarByIdSpecification(carId);
            var carEntity = await _carsRepository.GetSingleAsync(specification, cancellationToken);
            if (carEntity is null)
            {
                throw new NotFoundException($"Car with Id: {carId} doesn`t exist.");
            }

            return _mapper.Map<CarDto>(carEntity);
        }

        public async Task CreateCarAsync(
            CreateCarRequest createCarRequest,
            CancellationToken cancellationToken)
        {
            var carEntity = _mapper.Map<CarEntity>(createCarRequest);

            foreach (var image in createCarRequest.Images)
            {
                var imageUrl = await _imageService.WriteImageAsync(image, cancellationToken);
                carEntity.ImageUrls.Add(imageUrl);
            }

            await _carsRepository.CreateAsync(carEntity, cancellationToken);
        }

        public async Task UpdateCarAsync(
            Guid carId,
            UpdateCarRequest updateCarRequest,
            CancellationToken cancellationToken)
        {
            var specification = new GetCarByIdSpecification(carId);
            var carEntity = await _carsRepository.GetSingleAsync(
                specification,
                cancellationToken);
            if (carEntity is null)
            {
                throw new NotFoundException($"Car with Id: {carId} doesn`t exist.");
            }

            _mapper.Map(updateCarRequest, carEntity);

            carEntity.ImageUrls = updateCarRequest.Images is null
                ? carEntity.ImageUrls
                : await Task.WhenAll(updateCarRequest.Images.Select(img => _imageService.WriteImageAsync(img, cancellationToken)))
                            .ContinueWith(t => t.Result.ToList(), cancellationToken);

            await _carsRepository.UpdateAsync(
                carEntity,
                cancellationToken);
        }

        public async Task DeleteCarAsync(
            Guid carId,
            CancellationToken cancellationToken)
        {
            var specification = new GetCarByIdSpecification(carId);
            var carEntity = await _carsRepository.GetSingleAsync(
                specification,
                cancellationToken);
            if (carEntity is null)
            {
                throw new NotFoundException($"Car with Id: {carId} doesn`t exist.");
            }

            await _carsRepository.DeleteAsync(
                carEntity,
                cancellationToken);
        }
    }
}
