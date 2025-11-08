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
                .ForMember(dest => dest.ImageUrls, opt => opt.Ignore());
        }
    }
}
