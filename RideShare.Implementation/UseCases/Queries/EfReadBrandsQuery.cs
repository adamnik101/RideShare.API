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
    public class EfReadBrandsQuery : IReadBrandsQuery
    {
        private readonly RideshareContext _context;

        public EfReadBrandsQuery(RideshareContext context)
        {
            _context = context;
        }

        public int Id => 2;

        public string Name => "Read brands using Entity Framework";

        public PagedResponse<ReadBrandDto> Execute(SearchName search)
        {
            var query = _context.Brands.WhereActive().AsQueryable();

            if(search.Name != null)
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            return query.ToPagedResponse(search, x => new ReadBrandDto
            {   
                Name = x.Name,
                Models = x.Models.Select(z => new ReadModelDto
                {
                    Id = z.Id,
                    Name = z.Name
                })
            });
        }
    }
}
