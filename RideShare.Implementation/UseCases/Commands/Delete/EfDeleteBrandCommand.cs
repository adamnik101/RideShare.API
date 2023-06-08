using RideShare.Application.Exceptions;
using RideShare.Application.UseCases.Commands.Delete;
using RideShare.DataAccess;
using RideShare.Domain.Entities;
using RideShare.Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Implementation.UseCases.Commands.Delete
{
    public class EfDeleteBrandCommand : IDeleteBrandCommand
    {
        private readonly RideshareContext _context;

        public EfDeleteBrandCommand(RideshareContext context)
        {
            _context = context;
        }

        public int Id => 4;

        public string Name => "Delete brand using Entity Framework";

        public void Execute(int request)
        {
            var brandToDelete = _context.Brands.WhereActive().FirstOrDefault(x => x.Id == request);

            if (brandToDelete == null)
            {
                throw new EntityNotFoundException(request, nameof(Brand));
            }

            brandToDelete.DeletedAt = DateTime.Now;
            brandToDelete.IsDeleted = true;
            brandToDelete.IsActive = false;
            _context.SaveChanges();
        }
    }
}
