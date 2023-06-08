using FluentValidation;
using RideShare.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Implementation.Validators
{
    public class DeleteTypeValidator : AbstractValidator<int>
    {
        public DeleteTypeValidator(RideshareContext context) 
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x)
                .Must(id => context.Types.Any(x => x.Id == id)).WithMessage("Provided type with an ID of {PropertyValue} does not exist.")
                .Must(id => !context.Types.Any(x => x.Cars.Any(car => car.TypeId == id && !car.IsActive))).WithMessage("Type is associated with cars and cannot be deleted.");

        }
    }
}
