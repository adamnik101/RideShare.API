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
    public class CreateColorValidator : AbstractValidator<CreateNameOnlyDto>
    {
        public CreateColorValidator(RideshareContext context) 
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Name).NotEmpty().WithName("Color name is required.")
                .Must(x => !context.Colors.Any(y => y.Name == x)).WithMessage("Provided color already exists.");
        }
    }
}
