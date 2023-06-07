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
    public class EfReadBrandsQuery : IReadBrandsQuery
    {
        private readonly RideshareContext _context;

        public EfReadBrandsQuery(RideshareContext context)
        {
            _context = context;
        }

        public int Id => 2;

        public string Name => "Read brands using Entity Framework";

        public IEnumerable<ReadBrandDto> Execute(SearchNameDto search)
        {
            var query = _context.Brands.AsQueryable();

            if(search.Name != null)
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            var brands = query.Select(x => new ReadBrandDto
            {
                Name = x.Name,
                Models = x.Models.Select(y => new ReadModelDto
                {
                    Id = y.Id,
                    Name = y.Name,
                })
            }).ToList();

            return brands;
            

        }
    }
}
