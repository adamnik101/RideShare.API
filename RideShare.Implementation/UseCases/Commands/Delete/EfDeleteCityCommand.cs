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
    public class EfDeleteCityCommand : IDeleteCityCommand
    {
        private readonly RideshareContext _context;

        public EfDeleteCityCommand(RideshareContext context)
        {
            _context = context;
        }

        public int Id => 13;

        public string Name => "Delete city using Entity Framework";

        public void Execute(int request)
        {
            var cityToDelete = _context.Cities.WhereActive().FirstOrDefault(x => x.Id == request);

            if(cityToDelete == null)
            {
                throw new EntityNotFoundException(request, nameof(City));
            }

            cityToDelete.IsDeleted = true;
            cityToDelete.DeletedAt = DateTime.Now;
            cityToDelete.IsActive = false;

            _context.SaveChanges();
        }
    }
}
