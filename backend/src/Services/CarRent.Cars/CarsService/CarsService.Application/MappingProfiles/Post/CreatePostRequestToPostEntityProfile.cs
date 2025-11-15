using AutoMapper;
using CarsService.Application.Requests.Post;
using CarsService.Infrastructure.Entities;

namespace CarsService.Application.MappingProfiles.Post
{
    public class CreatePostRequestToPostEntityProfile
        : Profile
    {
        public CreatePostRequestToPostEntityProfile()
        {
            CreateMap<CreatePostRequest, PostEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.CarId, opt => opt.MapFrom(src => src.CarId))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.DiscountPercentage, opt => opt.MapFrom(src => src.DiscountPercentage))
                .ForMember(dest => dest.AverageRating, opt => opt.MapFrom(src => 0))
                .ForMember(dest => dest.PricePerDay, opt => opt.MapFrom(src => src.PricePerDay))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}
