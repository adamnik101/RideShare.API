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
    public class EfFindCityQuery : IFindCityQuery
    {
        private readonly RideshareContext _context;

        public EfFindCityQuery(RideshareContext context)
        {
            _context = context;
        }

        public int Id => 14;

        public string Name => "Find city using Entity Framework";

        public ReadCityDto Execute(int search)
        {
            var cityFound = _context.Cities.Find(search);

            if(cityFound == null)
            {
                throw new EntityNotFoundException(search, nameof(City));
            }

            var city = new ReadCityDto
            {
                Id = cityFound.Id,
                Name = cityFound.Name
            };

            return city;
        }
    }
}
