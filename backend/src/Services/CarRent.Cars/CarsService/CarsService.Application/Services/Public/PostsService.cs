using AutoMapper;
using CarsService.Application.DTOs;
using CarsService.Application.DTOs.Post;
using CarsService.Application.Exceptions;
using CarsService.Application.Interfaces.Public;
using CarsService.Application.Requests;
using CarsService.Application.Requests.Post;
using CarsService.Infrastructure.Entities;
using CarsService.Infrastructure.Interfaces;
using CarsService.Infrastructure.Specifications.Car;
using CarsService.Infrastructure.Specifications.Post;

namespace CarsService.Application.Services.Public
{
    public class PostsService : IPostsService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<PostEntity> _postsRepository;
        private readonly IRepository<CarEntity> _carsRepository;

        public PostsService(
            IMapper mapper,
            IRepository<PostEntity> postsRepository,
            IRepository<CarEntity> carsRepository)
        {
            _mapper = mapper;
            _postsRepository = postsRepository;
            _carsRepository = carsRepository;
        }

        public async Task<PaginatedResultDto<PostDto>> GetPaginatedPostsAsync(
            PostFilter postFilter,
            PaginationParams paginationParams,
            CancellationToken cancellationToken)
        {
            var (postsEntities, totalPages) = await _postsRepository.GetAsync(
                new PostByFilterSpecification(postFilter.CarBrand, postFilter.CarModel),
                paginationParams.PageIndex,
                paginationParams.PageSize,
                cancellationToken);

            return new PaginatedResultDto<PostDto>(
                _mapper.Map<ICollection<PostDto>>(postsEntities),
                paginationParams.PageSize,
                paginationParams.PageIndex,
                totalPages);
        }

        public async Task<PostDto> GetPostByIdAsync(
            Guid postId,
            CancellationToken cancellationToken)
        {
            var specification = new PostDetailsByIdSpecification(postId);
            var postEntity = await _postsRepository.GetSingleAsync(
                specification,
                cancellationToken);

            if (postEntity is null)
            {
                throw new NotFoundException($"Post with Id: {postId} doesn`t exist.");
            }

            return _mapper.Map<PostDto>(postEntity);
        }

        public async Task CreatePostAsync(
            CreatePostRequest createPostRequest,
            CancellationToken cancellationToken)
        {
            var carEntity = _carsRepository.GetSingleAsync(
                new CarByIdSpecification(createPostRequest.CarId),
                cancellationToken);
            if (carEntity is null)
            {
                throw new NotFoundException($"Car with Id: {createPostRequest.CarId} doesn`t exist.");
            }

            var postEntity = _mapper.Map<PostEntity>(createPostRequest);
            await _postsRepository.CreateAsync(
                postEntity,
                cancellationToken);
        }

        public async Task UpdatePostAsync(
            Guid postId,
            UpdatePostRequest updatePostRequest,
            CancellationToken cancellationToken)
        {
            var postEntity = await _postsRepository.GetSingleAsync(
                new PostByIdSpecification(postId),
                cancellationToken);
            if (postEntity is null)
            {
                throw new NotFoundException($"Post with Id: {postId} doesn`t exist.");
            }

            _mapper.Map(updatePostRequest, postEntity);

            await _postsRepository.UpdateAsync(
                postEntity,
                cancellationToken);

        }

        public async Task DeletePostAsync(
            Guid postId,
            CancellationToken cancellationToken)
        {
            var postEntity = await _postsRepository.GetSingleAsync(
                new PostByIdSpecification(postId),
                cancellationToken);
            if (postEntity is null)
            {
                throw new NotFoundException($"Post with Id: {postId} doesn`t exist.");
            }

            await _postsRepository.DeleteAsync(
                postEntity,
                cancellationToken);
        }
    }
}
