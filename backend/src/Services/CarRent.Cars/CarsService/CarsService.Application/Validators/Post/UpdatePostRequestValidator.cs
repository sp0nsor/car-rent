using CarsService.Application.Requests.Post;
using FluentValidation;

namespace CarsService.Application.Validators.Post
{
    public class UpdatePostRequestValidator : AbstractValidator<UpdatePostRequest>
    {
        public UpdatePostRequestValidator()
        {
            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("Description is a reuired field.")
                .MaximumLength(2000);

            RuleFor(p => p.DiscountPercentage)
                .InclusiveBetween(0, 100).WithMessage("DiscountPercentage can`t be negative or exxed 100.");

            RuleFor(p => p.PricePerDay)
                .NotEmpty().WithMessage("Price is a required field.")
                .Must(price => price > 0).WithMessage("Price can`t be negative.");
        }
    }
}
