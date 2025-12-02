using CarsService.Infrastructure.Entities;
using System.Linq.Expressions;

namespace CarsService.Infrastructure.Specifications.Post
{
    public class PostByFilterSpecification : Specification<PostEntity>
    {
        private readonly string? _carBrand;
        private readonly string? _carModel;

        public PostByFilterSpecification(
            string? carBrand,
            string? carModel)
        {
            _carBrand = carBrand;
            _carModel = carModel;
        }

        public override Expression<Func<PostEntity, bool>> ToExpression()
        {
            return p =>
                (_carBrand == null || p.Car.Brand == _carBrand) &&
                (_carModel == null || p.Car.Model == _carModel);
        }
    }
}
