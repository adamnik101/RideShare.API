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
    public class EfReadModelsQuery : IReadModelsQuery
    {
        private readonly RideshareContext _context;

        public EfReadModelsQuery(RideshareContext context)
        {
            _context = context;
        }

        public int Id => 7;

        public string Name => "Read models using Entity Framework";

        public IEnumerable<ReadModelDto> Execute(SearchNameDto search)
        {
            var query = _context.Models.AsQueryable();

            if(search.Name != null)
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            var models = query.Select(x => new ReadModelDto
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return models;
        }
    }
}
