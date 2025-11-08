using CarsService.Application.Interfaces.Public;
using CarsService.Application.Requests;
using CarsService.Application.Requests.Post;
using Microsoft.AspNetCore.Mvc;

namespace CarsService.API.Controllers
{
    [ApiController]
    [Route("posts")]
    public class PostsController : Controller
    {
        private readonly IPostsService _postsService;

        public PostsController(IPostsService postsService)
        {
            _postsService = postsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPaginatedPostsAsync(
            [FromQuery] PaginationParams paginationParams,
            CancellationToken cancellationToken)
        {
            var result = await _postsService.GetPaginatedPostsAsync(
                paginationParams,
                cancellationToken);

            return Ok(result);
        }

        [HttpGet("{postId:guid}")]
        public async Task<IActionResult> GetPostByIdAsync(
            [FromRoute] Guid postId,
            CancellationToken cancellationToken)
        {
            var result = await _postsService.GetPostByIdAsync(
                postId,
                cancellationToken);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePostAsync(
            [FromForm] CreatePostRequest createPostRequest,
            CancellationToken cancellationToken)
        {
            await _postsService.CreatePostAsync(
                createPostRequest,
                cancellationToken);

            return Created();
        }

        [HttpPut("{postId:guid}")]
        public async Task<IActionResult> UpdatePostAsync(
            [FromRoute] Guid postId,
            [FromForm] UpdatePostRequest updatePostRequest,
            CancellationToken cancellationToken)
        {
            await _postsService.UpdatePostAsync(
                postId,
                updatePostRequest,
                cancellationToken);

            return Accepted();
        }

        [HttpDelete("{postId:guid}")]
        public async Task<IActionResult> DeleltePostAsync(
            [FromRoute] Guid postId,
            CancellationToken cancellationToken)
        {
            await _postsService.DeletePostAsync(
                postId,
                cancellationToken);

            return NoContent();
        }
    }
}
