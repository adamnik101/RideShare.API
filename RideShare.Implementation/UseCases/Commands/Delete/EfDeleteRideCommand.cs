using FluentValidation;
using RideShare.Application.UseCases.Commands.Delete;
using RideShare.DataAccess;
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
        private readonly DeleteRideValidator _validator;
        public int Id => 310;

        public string Name => "Delete ride using Entity Framework";

        public void Execute(int request)
        {
            _validator.ValidateAndThrow(request);

            var ride = _context.Rides.WhereActive().FirstOrDefault(x => x.Id == request);

            ride.IsDeleted = true;
            ride.IsActive = false;
            ride.DeletedAt = DateTime.Now;

            _context.SaveChanges();
        }
    }
}
