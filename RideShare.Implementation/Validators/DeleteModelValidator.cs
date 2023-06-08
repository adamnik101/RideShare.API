using FluentValidation;
using RideShare.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Implementation.Validators
{
    public class DeleteModelValidator : AbstractValidator<int>
    {
        public DeleteModelValidator(RideshareContext context) 
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x)
                .Must(x => context.Models.Any(z => z.Id == x)).WithMessage("Model with a provided ID of {PropertyValue} does not exist.")
                .Must(x => !context.Models.Any(z => z.Cars.Any(y => y.ModelId == x && !y.IsDeleted))).WithMessage("Cannot delete model. Provided model exists for user car.");
        }
    }
}
