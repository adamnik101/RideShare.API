using FluentValidation;
using Microsoft.EntityFrameworkCore;
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
    public class EfDeleteModelCommand : IDeleteModelCommand
    {
        private readonly RideshareContext _context;
        public EfDeleteModelCommand(RideshareContext context)
        {
            _context = context;
        }

        public int Id => 8;

        public string Name => "Delete model using Entity Framework";

        public void Execute(int request)
        {
            var model = _context.Models.Include(x => x.Cars).FirstOrDefault(x => x.Id == request && x.IsActive);

            if (model == null)
            {
                throw new EntityNotFoundException(request, nameof(Model));
            }

            if(model.Cars.Any(car => car.IsActive))
            {
                throw new DeleteOperationException("Cannot delete model when some user has car model with an ID of " + request);
            }

            model.IsDeleted = true;
            model.DeletedAt = DateTime.UtcNow;
            model.IsActive = false;

            _context.SaveChanges();
        }
    }
}
