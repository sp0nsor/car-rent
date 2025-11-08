using CarsService.Infrastructure.Entities;
using System.Linq.Expressions;

namespace CarsService.Infrastructure.Specifications.Car
{
    public class GetCarByIdSpecification
        : Specification<CarEntity>
    {
        private readonly Guid _carId;

        public GetCarByIdSpecification(Guid carId)
        {
            _carId = carId;
        }

        public override Expression<Func<CarEntity, bool>> ToExpression()
        {
            return c => c.Id == _carId;
        }
    }
}
