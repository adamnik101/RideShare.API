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
    public class EfDeleteTypeCommand : IDeleteTypeCommand
    {
        private readonly RideshareContext _context;

        public EfDeleteTypeCommand(RideshareContext context)
        {
            _context = context;
        }

        public int Id => 200;

        public string Name => "Delete type using Entity Framework";

        public void Execute(int request)
        {
            var type = _context.Types.Include(x => x.Cars).FirstOrDefault(x => x.Id == request && x.IsActive);

            if (type == null)
            {
                throw new EntityNotFoundException(request, nameof(Domain.Entities.Type));
            }

            if (type.Cars.Any(car => car.IsActive))
            {
                throw new DeleteOperationException("Type cannot be deleted. There is a user car associated with provided type.");
            }

            type.IsDeleted = true;
            type.IsActive = false;
            type.DeletedAt = DateTime.Now;

            _context.SaveChanges();
        }
    }
}
