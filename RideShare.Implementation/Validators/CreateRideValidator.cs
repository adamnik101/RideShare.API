using FluentValidation;
using RideShare.Application;
using RideShare.Application.UseCases.DTOs.Create;
using RideShare.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Implementation.Validators
{
    public class CreateRideValidator : AbstractValidator<CreateRideDto>
    {
        public CreateRideValidator(RideshareContext context, IApplicationActor actor)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.StartTime)
                .NotEmpty().WithMessage("Start time is required.")
                .Must(ValidDateTime).WithMessage("Start time cannot be before today's date");


            RuleFor(x => x.StartCity)
                .NotEmpty().WithMessage("Start city is required.")
                .Must(x => context.Cities.Any(z => z.Id == x && z.IsActive)).WithMessage("Provided start city does not exist.");


            RuleFor(x => x.DestinationCity)
                .NotEmpty().WithMessage("Destination city is required.")
                .Must(x => context.Cities.Any(z => z.Id == x && z.IsActive)).WithMessage("Provided destination city does not exist.");

            RuleFor(x => x)
                .Must(x => x.StartCity != x.DestinationCity).WithMessage("Destination city cannot be the same as the start city.");
            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Ride price is required.")
                .Must(x => x > 0).WithMessage("Ride cannot be free.");
                
            RuleFor(x => x.CarId)
                .NotEmpty().WithMessage("Car is required.")
                .Must(x => context.Cars.Any(z => z.Id == x && z.IsActive && z.OwnerId == actor.Id)).WithMessage("Provided car does not exists.");

        }
        
        private bool ValidDateTime(DateTime time)
        {
            return time >= DateTime.Now;
        }
    
    }
}
