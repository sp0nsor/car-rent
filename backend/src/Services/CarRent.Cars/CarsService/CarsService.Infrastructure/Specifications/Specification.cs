using System.Linq.Expressions;

namespace CarsService.Infrastructure.Specifications
{
    public abstract class Specification<T> where T : class
    {
        public ICollection<Expression<Func<T, object>>> Includes { get; set; } = [];

        protected void AddInclude(Expression<Func<T, object>> includeExpression) =>
            Includes.Add(includeExpression);

        public abstract Expression<Func<T, bool>> ToExpression();
    }
}
