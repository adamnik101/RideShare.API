using FluentValidation;
using RideShare.Application;
using RideShare.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Implementation.Validators
{
    public class DeleteRideValidator : AbstractValidator<int>
    {
        public DeleteRideValidator(RideshareContext context, IApplicationActor actor) 
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x)
                .Must(x => context.Rides.Any(ride => ride.Id == x && ride.IsActive && ride.Driver.Id == actor.Id)).WithMessage("There is no ride to be deleted.");
        }
    }
}
