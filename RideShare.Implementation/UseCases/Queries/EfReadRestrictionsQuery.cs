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
    public class EfReadRestrictionsQuery : IReadRestrictionQuery
    {
        private readonly RideshareContext _context;

        public EfReadRestrictionsQuery(RideshareContext context)
        {
            _context = context;
        }
        public int Id => 73;

        public string Name => "Read restrictions using Entity Framework";

        public IEnumerable<ReadRestrictionDto> Execute(SearchNameDto search)
        {
            var query = _context.Restrictions.AsQueryable();

            if(search.Name != null)
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            var restrictions = query.Select(x => new ReadRestrictionDto { Name = x.Name, }).ToList();

            return restrictions;
        }
    }
}
