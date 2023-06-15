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
    public class EfUpdateModelCommand : IUpdateModelCommand
    {
        private readonly RideshareContext _context;

        public EfUpdateModelCommand(RideshareContext context)
        {
            _context = context;
        }

        public int Id => 344;

        public string Name => "Update model using Entity Framework";

        public void Execute(UpdateModel request)
        {
            var id = request.Id;
            var name = request.Name;
            var brandId = request.BrandId;

            var model = _context.Models.Find(id);

            if (model == null)
            {
                throw new EntityNotFoundException(id, nameof(Model));
            }

            if(name != null)
            {
                model.Name = name;
            }

            if(brandId != null)
            {
                var brand = _context.Brands.Find(brandId);

                if(brand == null)
                {
                    throw new EntityNotFoundException((int)brandId, nameof(Brand));
                }
                model.BrandId = brand.Id;
            }

            _context.SaveChanges();

        }
    }
}
