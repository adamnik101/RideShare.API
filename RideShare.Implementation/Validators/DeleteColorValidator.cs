using FluentValidation;
using RideShare.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Implementation.Validators
{
    public class DeleteColorValidator : AbstractValidator<int>
    {
        public DeleteColorValidator(RideshareContext context) 
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x).Must(x => context.Colors.Any(y => y.Id == x)).WithMessage("Color with an ID of {PropertyValue} does not exist.")
                           .Must(x => !context.Colors.Any(z => z.Cars.Any(y => y.ColorId == x && !y.IsDeleted))).WithMessage("Cannot delete a color that a user car has.");
        }
    }
}
