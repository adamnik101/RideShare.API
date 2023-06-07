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
            var modelToDelete = _context.Models.Find(request);

            if (modelToDelete == null)
            {
                throw new EntityNotFoundException(request, nameof(Model));
            }
            modelToDelete.IsDeleted = true;
            modelToDelete.DeletedAt = DateTime.UtcNow;
            modelToDelete.IsActive = false;

            _context.SaveChanges();
        }
    }
}
