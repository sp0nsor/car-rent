using CarsService.Infrastructure.Entities;
using System.Linq.Expressions;

namespace CarsService.Infrastructure.Specifications.Post
{
    public class PostByIdSpecification : Specification<PostEntity>
    {
        private readonly Guid _postId;

        public PostByIdSpecification(Guid postId)
        {
            _postId = postId;
        }

        public override Expression<Func<PostEntity, bool>> ToExpression()
        {
            return p => p.Id == _postId;
        }
    }
}
