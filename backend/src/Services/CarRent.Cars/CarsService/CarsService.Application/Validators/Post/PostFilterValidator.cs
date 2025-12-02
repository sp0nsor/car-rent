using CarsService.Application.Requests.Post;
using FluentValidation;

namespace CarsService.Application.Validators.Post
{
    public class PostFilterValidator : AbstractValidator<PostFilter>
    {
        public PostFilterValidator()
        {
            RuleFor(c => c.CarBrand)
                .MaximumLength(50).WithMessage("Brand can`t exeed 50 characters.");

            RuleFor(c => c.CarModel)
                .MaximumLength(50).WithMessage("Model can`t exeed 50 characters.");
        }
    }
}
