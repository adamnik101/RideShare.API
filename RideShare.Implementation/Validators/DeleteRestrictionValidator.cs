using FluentValidation;
using RideShare.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Implementation.Validators
{
    public class DeleteRestrictionValidator : AbstractValidator<int>
    {
        public DeleteRestrictionValidator(RideshareContext context) 
        {
            RuleFor(x => x).Must(y => context.Restrictions.Any(z => z.Id == y))
                .WithMessage("Restriction with an ID of {PropertyValue} does not exist.");
        }
    }
}
