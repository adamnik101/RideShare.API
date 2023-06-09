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
    public class EfDeleteColorCommand : IDeleteColorCommand
    {
        private readonly RideshareContext _context;
        public EfDeleteColorCommand(RideshareContext context)
        {
            _context = context;
        }

        public int Id => 53;

        public string Name => "Delete color using Entity Framework";

        public void Execute(int request)
        {
            var color = _context.Colors.Include(x => x.Cars).FirstOrDefault(x => x.Id == request);

            if (color == null)
            {
                throw new EntityNotFoundException(request, nameof(Color));
            }

            if (color.Cars.Any(car => car.IsActive))
            {
                throw new DeleteOperationException($"Cannot delete color. Car with {color.Name} exists");
            }


            color.IsDeleted = true;
            color.DeletedAt = DateTime.UtcNow;
            color.IsActive = false;

            _context.SaveChanges();
        }
    }
}
