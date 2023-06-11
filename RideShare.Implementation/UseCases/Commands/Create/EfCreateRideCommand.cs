using FluentValidation;
using RideShare.Application;
using RideShare.Application.UseCases.Commands.Create;
using RideShare.Application.UseCases.DTOs.Create;
using RideShare.DataAccess;
using RideShare.Domain.Entities;
using RideShare.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Implementation.UseCases.Commands.Create
{
    public class EfCreateRideCommand : ICreateRideCommand
    {
        private readonly RideshareContext _context;
        private readonly CreateRideValidator _validator;
        private readonly IApplicationActor _actor;

        public EfCreateRideCommand(RideshareContext context, CreateRideValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }
        public int Id => 300;

        public string Name => "Create ride using Entity Framework";

        public void Execute(CreateRideDto request)
        {
            _validator.ValidateAndThrow(request);

            Ride ride = new Ride
            {
                StartDate = request.StartTime,
                StartCityId = request.StartCity,
                EndCityId = request.DestinationCity,
                CarId = request.CarId,
                DriverId = _actor.Id,
                Price = request.Price,
            };

            _context.Rides.Add(ride);
            _context.SaveChanges();
        }
    }
}
