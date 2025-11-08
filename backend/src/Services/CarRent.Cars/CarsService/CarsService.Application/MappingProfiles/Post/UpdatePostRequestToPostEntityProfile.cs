using AutoMapper;
using CarsService.Application.Requests.Post;
using CarsService.Infrastructure.Entities;

namespace CarsService.Application.MappingProfiles.Post
{
    public class UpdatePostRequestToPostEntityProfile : Profile
    {
        public UpdatePostRequestToPostEntityProfile()
        {
            CreateMap<UpdatePostRequest, PostEntity>()
                .ForMember(dest => dest.Id, opt => opt.UseDestinationValue())
                .ForMember(dest => dest.CarId, opt => opt.UseDestinationValue())
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.DiscountPercentage, opt => opt.MapFrom(src => src.DiscountPercentage))
                .ForMember(dest => dest.AverageRating, opt => opt.UseDestinationValue())
                .ForMember(dest => dest.PricePerDay, opt => opt.MapFrom(src => src.PricePerDay))
                .ForMember(dest => dest.CreatedAt, opt => opt.UseDestinationValue())
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}
