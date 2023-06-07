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
    public class EfReadTypesQuery : IReadTypesQuery
    {
        private readonly RideshareContext _context;

        public EfReadTypesQuery(RideshareContext context)
        {
            _context = context;
        }

        public int Id => 16;

        public string Name => "Read car types using Entity Framework";

        public IEnumerable<ReadTypeDto> Execute(SearchNameDto search)
        {
            var query = _context.Types.AsQueryable();

            if(search.Name != null) 
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            var brands = query.Select(x => new ReadTypeDto
            {
                Name = x.Name
            }).ToList();

            return brands;

        }
    }
}
