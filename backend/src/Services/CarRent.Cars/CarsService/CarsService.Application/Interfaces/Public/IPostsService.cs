using CarsService.Application.DTOs;
using CarsService.Application.DTOs.Post;
using CarsService.Application.Requests;
using CarsService.Application.Requests.Post;

namespace CarsService.Application.Interfaces.Public
{
    public interface IPostsService
    {
        Task<PaginatedResultDto<PostDto>> GetPaginatedPostsAsync(PostFilter postFilter, PaginationParams paginationParams, CancellationToken cancellationToken);
        Task<PostDto> GetPostByIdAsync(Guid postId, CancellationToken cancellationToken);
        Task CreatePostAsync(CreatePostRequest createPostRequest, CancellationToken cancellationToken);
        Task UpdatePostAsync(Guid postId, UpdatePostRequest updatePostRequest, CancellationToken cancellationToken);
        Task DeletePostAsync(Guid postId, CancellationToken cancellationToken);
    }
}