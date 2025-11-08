using CarsService.Infrastructure.Entities;
using System.Linq.Expressions;

namespace CarsService.Infrastructure.Specifications.Car
{
    public class GetAllCarsSpecification
        : Specification<CarEntity>
    {
        public override Expression<Func<CarEntity, bool>> ToExpression()
        {
            return c => c is CarEntity;
        }
    }
}
