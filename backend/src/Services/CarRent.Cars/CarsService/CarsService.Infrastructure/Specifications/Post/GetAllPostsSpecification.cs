using CarsService.Infrastructure.Entities;
using System.Linq.Expressions;

namespace CarsService.Infrastructure.Specifications.Post
{
    public class GetAllPostsSpecification : Specification<PostEntity>
    {
        public override Expression<Func<PostEntity, bool>> ToExpression()
        {
            return p => p is PostEntity;
        }
    }
}
