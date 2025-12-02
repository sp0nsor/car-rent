using CarsService.Infrastructure.Entities;
using System.Linq.Expressions;

namespace CarsService.Infrastructure.Specifications.Post
{
    public class PostsByCarAttributesSpecification : Specification<PostEntity>
    {
        private readonly string _carBrand;
        private readonly string _carModel;

        public PostsByCarAttributesSpecification(
            string carModel,
            string carBrand)
        {
            _carModel = carModel;
            _carBrand = carBrand;
        }

        public override Expression<Func<PostEntity, bool>> ToExpression()
        {
            return p => p.Car.Brand == _carBrand && p.Car.Model == _carModel;
        }
    }
}
