using RideShare.Application.UseCases.DTOs.Read;
using RideShare.Application.UseCases.Queries;
using RideShare.Application.UseCases.Queries.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Implementation.UseCases.Queries
{
    public class EfReadRidesQuery : IReadRidesQuery
    {
        public int Id => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        public IEnumerable<ReadRideDto> Execute(SearchRideDto search)
        {
            throw new NotImplementedException();
        }
    }
}
