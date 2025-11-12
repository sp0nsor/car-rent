using CarsService.Application.Requests.Post;
using FluentValidation;

namespace CarsService.Application.Validators.Post
{
    public class CreatePostRequestValidator : AbstractValidator<CreatePostRequest>
    {
        public CreatePostRequestValidator()
        {
            RuleFor(p => p.CarId)
                .NotEmpty().WithMessage("Car id is a required field.")
                .Must(id => id != Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6")).WithMessage("Invalid car id.");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("Description is required field.")
                .MaximumLength(2000);

            RuleFor(p => p.DiscountPercentage)
                .InclusiveBetween(1, 100).WithMessage("DiscountPercentage can`t be negative or exxed 100.");

            RuleFor(p => p.PricePerDay)
                .NotEmpty().WithMessage("Price is a required field.")
                .Must(price => price > 0).WithMessage("Price can`t be negative.");
        }
    }
}
