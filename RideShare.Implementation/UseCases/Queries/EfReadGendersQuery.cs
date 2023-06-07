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
    public class EfReadGendersQuery : IReadGendersQuery
    {
        private readonly RideshareContext _context;

        public EfReadGendersQuery(RideshareContext context)
        {
            _context = context;
        }

        public int Id => 900;

        public string Name => "Read genders using Entity Framework";

        public IEnumerable<ReadGenderDto> Execute(string search)
        {
            return _context.Genders.Select(x => new ReadGenderDto {Id = x.Id, Name = x.Name});
        }
    }
}
