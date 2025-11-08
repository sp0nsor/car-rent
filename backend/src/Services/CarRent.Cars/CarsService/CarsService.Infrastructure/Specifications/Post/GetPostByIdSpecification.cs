using CarsService.Infrastructure.Entities;
using System.Linq.Expressions;

namespace CarsService.Infrastructure.Specifications.Post
{
    public class GetPostByIdSpecification : Specification<PostEntity>
    {
        private readonly Guid _postId;

        public GetPostByIdSpecification(Guid postId)
        {
            _postId = postId;
        }

        public override Expression<Func<PostEntity, bool>> ToExpression()
        {
            return p => p.Id == _postId;
        }
    }
}
