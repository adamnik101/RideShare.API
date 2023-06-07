using RideShare.Application.Exceptions;
using RideShare.Application.UseCases.DTOs.Read;
using RideShare.Application.UseCases.Queries;
using RideShare.DataAccess;
using RideShare.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Implementation.UseCases.Queries
{
    public class EfFindBrandQuery : IFindBrandQuery
    {
        private readonly RideshareContext _context;

        public EfFindBrandQuery(RideshareContext context)
        {
            _context = context;
        }

        public int Id => 3;

        public string Name => "Find specific brand using Entity Framework";

        public ReadBrandDto Execute(int search)
        {
            var brandFound = _context.Brands.Find(search);

            if(brandFound == null)
            {
                throw new EntityNotFoundException(search, nameof(Brand));
            }

            var brand = new ReadBrandDto
            {
                Name = brandFound.Name
            };

            if(brand.Models != null)
            {
                brand.Models = brandFound.Models.Select(y => new ReadModelDto
                {
                    Id = y.Id,
                    Name = y.Name,
                });
            }

            return brand;

        }
    }
}
