using FluentValidation;
using RideShare.Application.UseCases.DTOs.Create;
using RideShare.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Implementation.Validators
{
    public class CreateCarValidator : AbstractValidator<CreateCarDto>
    {
        private int currentYear = DateTime.Now.Year;
        public CreateCarValidator(RideshareContext context) 
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.ModelId).NotEmpty().WithMessage("Model is required.")
                .Must(y => context.Models.Any(x => x.Id == y)).WithMessage("Model provided does not exist.");

            RuleFor(x => x.ColorId).NotEmpty().WithMessage("Color is required.")
                .Must(y => context.Colors.Any(x => x.Id == y)).WithMessage("Provided color does not exist.");

            RuleFor(x => x.TypeId).NotEmpty().WithMessage("Type is required.")
                .Must(y => context.Types.Any(x => x.Id == y)).WithMessage("Provided type does not exist.");

            var licenceplateRegEx = @"^[A-ZŠŠĐČĆŽ]{2}-([0-9]){3,5}-[A-Z]{2}";
            RuleFor(x => x.LicencePlate).NotEmpty().WithMessage("Licence plate is required.")
                .Matches(licenceplateRegEx).WithMessage("Licence plate is in wrong format. Example: BG-001-BG");

            RuleFor(x => x.FirstRegistration).NotEmpty().WithMessage("First registration date is required.")
                .Must(BeValidDateTime).WithMessage("First registration date is not valid.");

            RuleFor(x => x.NumberOfSeats)
                .NotEmpty().WithMessage("Number of available seats is required.")
                .InclusiveBetween(1, 4).WithMessage("Number of available seats must be between 1 and 4");
        }

        protected bool BeValidDateTime(int firstRegistration)
        {
            if(firstRegistration > currentYear)
            {
                return false;
            }
            return true;
        }
    }
}
