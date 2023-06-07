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
    public class CreateTypeValidator : AbstractValidator<CreateNameOnlyDto>
    {
        public CreateTypeValidator(RideshareContext context) 
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Name).NotEmpty().WithMessage("Type name is required.")

                .Must(x => !context.Types.Any(y => y.Name == x)).WithMessage("Provided car type already exists.");
        }
    }
}
