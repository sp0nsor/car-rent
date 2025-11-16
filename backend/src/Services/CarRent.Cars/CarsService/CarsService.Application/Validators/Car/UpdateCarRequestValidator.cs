using CarsService.Application.Requests.Car;
using FluentValidation;

namespace CarsService.Application.Validators.Car
{
    public class UpdateCarRequestValidator : AbstractValidator<UpdateCarRequest>
    {
        public UpdateCarRequestValidator()
        {
            RuleFor(c => c.Brand)
                .NotEmpty().WithMessage("Brand is a required field.")
                .MaximumLength(50).WithMessage("Brand can`t exeed 50 characters.");

            RuleFor(c => c.Model)
                .NotEmpty().WithMessage("Model is a required field.")
                .MaximumLength(50).WithMessage("Model can`t exeed 50 characters.");

            RuleFor(c => c.Color)
                .NotEmpty().WithMessage("Color is a required field.")
                .MaximumLength(50).WithMessage("Color can`t exxed 50 characters.");

            RuleFor(c => c.CarType)
                .IsInEnum().WithMessage("Invalid car type.");

            RuleFor(c => c.TransmissionType)
                .IsInEnum().WithMessage("Invalid steering type.");

            RuleFor(c => c.SeatsCount)
                .NotEmpty().WithMessage("Seats count is a required field.")
                .InclusiveBetween(1, 20).WithMessage("Seats count can`t be negative or exeed 20.");

            RuleFor(c => c.DrivingRange)
                .NotEmpty().WithMessage("Driving range is a required field.")
                .InclusiveBetween(1, 2000).WithMessage("Driving range can`t be negative or exeed 2000 km.");

            RuleFor(c => c.ReleaseYear)
                .NotEmpty().WithMessage("Release year is a required field.")
                .InclusiveBetween(1885, DateTime.UtcNow.Year).WithMessage("Release year is invalid.");

            RuleFor(c => c.Power)
                .NotEmpty().WithMessage("Power is a required filed.")
                .Must(p => p > 0).WithMessage("Power can`t be negative.");

            RuleFor(c => c.Images)
                .NotEmpty().WithMessage("Images is a required field.")
                .Must(img => img?.Count <= 20).WithMessage("Max size is 20 images.");
        }
    }
}
