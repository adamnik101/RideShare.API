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
    public class CreateModelValidator : AbstractValidator<CreateModelDto>
    {
        public CreateModelValidator(RideshareContext context) 
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Name).NotEmpty().WithMessage("Model name is required.");

            RuleFor(x => x.BrandId).NotEmpty().WithMessage("Brand is required.")
                .Must(x => context.Brands.Any(y => y.Id == x)).WithMessage("Provided brand does not exist.");
        }
    }
}
