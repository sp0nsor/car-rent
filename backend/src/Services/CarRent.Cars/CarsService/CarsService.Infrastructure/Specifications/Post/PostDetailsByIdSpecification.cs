using CarsService.Infrastructure.Entities;
using System.Linq.Expressions;

namespace CarsService.Infrastructure.Specifications.Post
{
    public class PostDetailsByIdSpecification
        : Specification<PostEntity>
    {
        private readonly Guid _postId;

        public PostDetailsByIdSpecification(Guid postId)
        {
            _postId = postId;

            AddInclude(p => p.Car);
        }

        public override Expression<Func<PostEntity, bool>> ToExpression()
        {
            return p => p.Id == _postId;
        }
    }
}
