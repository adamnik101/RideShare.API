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
    public class EfReadColorsQuery : IReadColorsQuery
    {
        private readonly RideshareContext _context;

        public EfReadColorsQuery(RideshareContext context)
        {
            _context = context;
        }

        public int Id => 52;

        public string Name => "Read colors using Entity Framework";

        public PagedResponse<ReadColorDto> Execute(SearchName search)
        {
            var query = _context.Colors.WhereActive().AsQueryable();
            
            if(search.Name != null)
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            return query.ToPagedResponse(search, x => new ReadColorDto { Id = x.Id,Name = x.Name });
        }
    }
}
