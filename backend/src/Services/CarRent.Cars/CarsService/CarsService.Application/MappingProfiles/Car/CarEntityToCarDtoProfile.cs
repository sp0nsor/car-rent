using AutoMapper;
using CarsService.Application.DTOs.Car;
using CarsService.Infrastructure.Entities;

namespace CarsService.Application.MappingProfiles.Car
{
    public class CarEntityToCarDtoProfile : Profile
    {
        public CarEntityToCarDtoProfile()
        {
            CreateMap<CarEntity, CarDto>()
                .ConstructUsing(src => new CarDto(
                    src.Id,
                    src.Model,
                    src.Brand,
                    src.Color,
                    src.CarType.ToString(),
                    src.TransmissionType.ToString(),
                    src.SeatsCount,
                    src.DrivingRange,
                    src.ReleaseYear,
                    src.Power,
                    src.ImageUrls
                ));
        }
    }
}
