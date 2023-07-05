using RideShare.Application.UseCases.DTOs;
using RideShare.Application.UseCases.DTOs.Read;
using RideShare.Application.UseCases.Queries;
using RideShare.Application.UseCases.Queries.Searches;
using RideShare.DataAccess;
using RideShare.Implementation.Extensions;
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

        public PagedResponse<ReadRestrictionDto> Execute(SearchName search)
        {
            var query = _context.Restrictions.WhereActive().AsQueryable();

            if(search.Name != null)
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }
            return query.ToPagedResponse(search, x => new ReadRestrictionDto
            {
                Id = x.Id,
                Name = x.Name
            });
        }
    }
}
