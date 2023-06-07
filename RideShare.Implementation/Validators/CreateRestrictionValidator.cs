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
    public class CreateRestrictionValidator : AbstractValidator<CreateNameOnlyDto>
    {
        public CreateRestrictionValidator(RideshareContext context) 
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Name).NotEmpty().WithMessage("Restriction name is required.")
                .Must(x => !context.Restrictions.Any(z => z.Name == x)).WithMessage("Provided restriction already exists.");
        }
    }
}
