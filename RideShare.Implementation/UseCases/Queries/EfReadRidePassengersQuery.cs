using Microsoft.EntityFrameworkCore;
using RideShare.Application.Exceptions;
using RideShare.Application.UseCases.DTOs.Read;
using RideShare.Application.UseCases.Queries;
using RideShare.DataAccess;
using RideShare.Domain.Entities;
using RideShare.Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Implementation.UseCases.Queries
{
    public class EfReadRidePassengersQuery : IReadRidePassengersQuery
    {
        private readonly RideshareContext _context;

        public EfReadRidePassengersQuery(RideshareContext context)
        {
            _context = context;
        }

        public int Id => 280;

        public string Name => "Read ride passengers using Entity Framework";

        public IEnumerable<ReadRidePassengerDto> Execute(int search)
        {
            var ride = _context.Rides.Include(x => x.RideRequests).ThenInclude(z => z.FromUser).ThenInclude(y => y.Gender).WhereActive().FirstOrDefault(x => x.Id == search);

            if (ride == null)
            {
                throw new EntityNotFoundException(search, nameof(Ride));
            }

            return ride.RideRequests.Where(x => x.RideId == search).Select(x => new ReadRidePassengerDto
            {
                Id = x.Id,
                Fullname = x.FromUser.FirstName + " " + x.FromUser.LastName,
                Email = x.FromUser.Email,
                Gender = x.FromUser.Gender.Name,
            });
        }
    }
}
