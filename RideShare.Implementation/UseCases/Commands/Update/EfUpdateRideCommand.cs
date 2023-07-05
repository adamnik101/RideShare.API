using RideShare.Application;
using RideShare.Application.Exceptions;
using RideShare.Application.UseCases.Commands.Update;
using RideShare.Application.UseCases.DTOs.Update;
using RideShare.DataAccess;
using RideShare.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Implementation.UseCases.Commands.Update
{
    public class EfUpdateRideCommand : IUpdateRideCommand
    {
        private readonly RideshareContext _context;
        private readonly IApplicationActor _actor;

        public EfUpdateRideCommand(RideshareContext context, IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }
        public int Id => 350;

        public string Name => "Update ride using Entity Framework";

        public void Execute(UpdateRide request)
        {
            var ride = _context.Rides.FirstOrDefault(x => x.Id == request.Id && x.DriverId == _actor.Id);

            if(ride == null)
            {
                throw new EntityNotFoundException(request.Id, nameof(Ride));
            }

            if(request.StartDate.HasValue)
            {
                ride.StartDate = (DateTime)request.StartDate;
            }
            if(request.StartCityId.HasValue)
            {
                ride.StartCityId = (int)request.StartCityId;
            }
            if (request.EndCityId.HasValue)
            {
                ride.EndCityId = (int)request.EndCityId;
            }
            if (request.CarId.HasValue)
            {
                ride.CarId = (int)request.CarId;
            }

            _context.SaveChanges();
        }
    }
}
