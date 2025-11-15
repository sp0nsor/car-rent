using AutoMapper;
using CarsService.Application.Requests.Car;
using CarsService.Infrastructure.Entities;

namespace CarsService.Application.MappingProfiles.Car
{
    public class UpdateCarRequestToCarEntityProfile : Profile
    {
        public UpdateCarRequestToCarEntityProfile()
        {
            CreateMap<UpdateCarRequest, CarEntity>()
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color))
                .ForMember(dest => dest.CarType, opt => opt.MapFrom(src => src.CarType))
                .ForMember(dest => dest.TransmissionType, opt => opt.MapFrom(src => src.TransmissionType))
                .ForMember(dest => dest.SeatsCount, opt => opt.MapFrom(src => src.SeatsCount))
                .ForMember(dest => dest.DrivingRange, opt => opt.MapFrom(src => src.DrivingRange))
                .ForMember(dest => dest.ReleaseYear, opt => opt.MapFrom(src => src.ReleaseYear))
                .ForMember(dest => dest.Power, opt => opt.MapFrom(src => src.Power))
                .ForMember(dest => dest.ImageUrls, opt => opt.UseDestinationValue());
        }
    }
}
