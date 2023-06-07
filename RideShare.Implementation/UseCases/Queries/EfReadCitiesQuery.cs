using RideShare.Application.UseCases.DTOs.Read;
using RideShare.Application.UseCases.Queries;
using RideShare.Application.UseCases.Queries.Searches;
using RideShare.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Implementation.UseCases.Queries
{
    public class EfReadCitiesQuery : IReadCitiesQuery
    {
        private readonly RideshareContext _context;

        public EfReadCitiesQuery(RideshareContext context)
        {
            _context = context;
        }

        public int Id => 12;

        public string Name => "Read cities using Entity Framework";

        public IEnumerable<ReadCityDto> Execute(SearchNameDto search)
        {
            var query = _context.Cities.AsQueryable();

            if(search.Name != null)
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            var cities = query.Select(x => new ReadCityDto
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return cities;
        }
    }
}
