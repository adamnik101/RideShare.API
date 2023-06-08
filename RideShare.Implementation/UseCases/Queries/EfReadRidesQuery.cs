using Microsoft.EntityFrameworkCore;
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
    public class EfReadRidesQuery : IReadRidesQuery
    {
        private readonly RideshareContext _context;

        public EfReadRidesQuery(RideshareContext context)
        {
            _context = context;
        }

        public int Id => 301;

        public string Name => "Search rides using Entity Framework";

        public PagedResponse<ReadRideDto> Execute(SearchRideDto search)
        {
            var query = _context.Rides
                .Include(x => x.StartCity)
                .Include(x => x.EndCity)
                .Include(x => x.Driver)
                .Include(x => x.Car)
                .Where(x => x.StartCityId == search.StartCity
                            && x.EndCityId == search.DestinationCity
                            && x.StartDate.Year == search.RideDate.Year
                            && x.StartDate.Month == search.RideDate.Month
                            && x.StartDate.Day == search.RideDate.Day
                            && x.StartDate > DateTime.Now)
                .WhereActive();

            return query.ToPagedResponse(search, x => new ReadRideDto
            {
                StartCity = new ReadCityDto
                {
                    Id = x.StartCity.Id,
                    Name = x.StartCity.Name
                },
                DestinationCity = new ReadCityDto
                {
                    Id = x.EndCity.Id,
                    Name = x.EndCity.Name 
                },
                StartDate = x.StartDate,
                Driver = new ReadDriverDto
                {
                    Id = x.Driver.Id,
                    FirstName = x.Driver.FirstName,
                    LastName = x.Driver.LastName,
                    PhoneNumber = x.Driver.PhoneNumber,
                    Email = x.Driver.Email,
                }, 
                Car = new ReadDriverCarDto
                {
                    LicencePlate = x.Car.LicencePlate,
                    ModelBrand = x.Car.Model.Name + " " + x.Car.Model.Brand.Name,
                    Color = x.Car.Color.Name,
                    Type = x.Car.Type.Name,
                    NumberOfSeats = x.Car.NumberOfSeats,
                    FirstRegistration = x.Car.FirstRegistration,
                    ImagePath = x.Car.ImagePath
                }
            });

                                    
        }
    }
}
