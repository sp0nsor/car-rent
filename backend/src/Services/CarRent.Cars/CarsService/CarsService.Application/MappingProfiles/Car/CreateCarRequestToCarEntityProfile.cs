using AutoMapper;
using CarsService.Application.Requests.Car;
using CarsService.Infrastructure.Entities;

namespace CarsService.Application.MappingProfiles.Car
{
    public class CreateCarRequestToCarEntityProfile : Profile
    {
        public CreateCarRequestToCarEntityProfile()
        {
            CreateMap<CreateCarRequest, CarEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.ImageUrls, opt => opt.Ignore());
        }
    }
}
