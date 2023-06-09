using RideShare.Application;
using RideShare.Application.Exceptions;
using RideShare.Application.UseCases.Commands.Delete;
using RideShare.DataAccess;
using RideShare.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Implementation.UseCases.Commands.Delete
{
    public class EfDeleteCarCommand : IDeleteCarCommand
    {
        private readonly IApplicationActor _actor;
        private readonly RideshareContext _context;

        public EfDeleteCarCommand(RideshareContext context, IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }

        public int Id => 800;

        public string Name => "Delete car using Entity Framework";

        public void Execute(int request)
        {
            var car = _context.Cars.FirstOrDefault(x => x.Id == request && x.IsActive && x.OwnerId == _actor.Id);

            if(car == null)
            {
                throw new EntityNotFoundException(request, nameof(Car));
            }

            car.IsDeleted = true;
            car.DeletedAt = DateTime.UtcNow;
            car.IsActive = false;
            
            _context.SaveChanges();
        }
    }
}
