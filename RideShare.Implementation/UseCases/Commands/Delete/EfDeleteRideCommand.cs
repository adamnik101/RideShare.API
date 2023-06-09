using FluentValidation;
using RideShare.Application;
using RideShare.Application.Exceptions;
using RideShare.Application.UseCases.Commands.Delete;
using RideShare.DataAccess;
using RideShare.Domain.Entities;
using RideShare.Implementation.Extensions;
using RideShare.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Implementation.UseCases.Commands.Delete
{
    public class EfDeleteRideCommand : IDeleteRideCommand
    {
        private readonly RideshareContext _context;
        private readonly IApplicationActor _actor;

        public EfDeleteRideCommand(IApplicationActor actor, RideshareContext context)
        {
            _actor = actor;
            _context = context;
        }

        public int Id => 310;

        public string Name => "Delete ride using Entity Framework";

        public void Execute(int request)
        {
            var ride = _context.Rides.FirstOrDefault(x => x.Id == request && x.IsActive && x.DriverId == _actor.Id);
            
            if (ride == null)
            {
                throw new EntityNotFoundException(request, nameof(Ride));
            }

            ride.IsDeleted = true;
            ride.IsActive = false;
            ride.DeletedAt = DateTime.Now;

            _context.SaveChanges();
        }
    }
}
