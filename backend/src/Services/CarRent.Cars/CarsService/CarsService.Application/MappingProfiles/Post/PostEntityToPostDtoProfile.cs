using AutoMapper;
using CarsService.Application.DTOs.Post;
using CarsService.Infrastructure.Entities;

namespace CarsService.Application.MappingProfiles.Post
{
    public class PostEntityToPostDtoProfile : Profile
    {
        public PostEntityToPostDtoProfile()
        {
            CreateMap<PostEntity, PostDto>();
        }
    }
}
