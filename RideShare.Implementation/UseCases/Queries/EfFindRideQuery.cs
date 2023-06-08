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
    public class EfFindRideQuery : IFindRideQuery
    {
        private readonly RideshareContext _context;

        public EfFindRideQuery(RideshareContext context)
        {
            _context = context;
        }

        public int Id => 302;

        public string Name => "Find ride using Entity Framework";

        public ReadRideDto Execute(int search)
        {
            var ride = _context.Rides.WhereActive().FirstOrDefault(x => x.Id == search);

            if(ride == null) 
            {
                throw new EntityNotFoundException(search, nameof(Ride));
            }

            return new ReadRideDto
            {
                StartCity = new ReadCityDto
                {
                    Id = ride.StartCity.Id,
                    Name = ride.StartCity.Name
                },
                DestinationCity = new ReadCityDto
                {
                    Id = ride.EndCity.Id,
                    Name = ride.EndCity.Name
                },
                StartDate = ride.StartDate,
                Driver = new ReadDriverDto
                {
                    Id = ride.Driver.Id,
                    FirstName = ride.Driver.FirstName,
                    LastName = ride.Driver.LastName,
                    PhoneNumber = ride.Driver.PhoneNumber,
                    Email = ride.Driver.Email,
                },
                Car = new ReadDriverCarDto
                {
                    LicencePlate = ride.Car.LicencePlate,
                    ModelBrand = ride.Car.Model.Name + " " + ride.Car.Model.Brand.Name,
                    Color = ride.Car.Color.Name,
                    Type = ride.Car.Type.Name,
                    NumberOfSeats = ride.Car.NumberOfSeats,
                    FirstRegistration = ride.Car.FirstRegistration,
                    ImagePath = ride.Car.ImagePath
                }
            };
        }
    }
}
