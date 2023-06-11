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
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Implementation.UseCases.Queries
{
    public class EfReadUsersQuery : IReadUsersQuery
    {
        private readonly RideshareContext _context;

        public EfReadUsersQuery(RideshareContext context)
        {
            _context = context;
        }

        public int Id => 556;

        public string Name => "Read users using Entity Framework";

        public PagedResponse<ReadUserDto> Execute(SearchUser search)
        {
            var query = _context.Users.Include(x => x.Rides).Include(x => x.Cars).ThenInclude(x => x.Color).Include(x => x.Cars).ThenInclude(x => x.Type).Include(x => x.Cars).ThenInclude(x => x.CarRestrictions).ThenInclude(x => x.Restriction).Include(x => x.Cars).ThenInclude(x => x.Model).ThenInclude(x => x.Brand).Include(x => x.Gender).Include(x => x.Role).WhereActive().AsQueryable();
        
            if(search.FirstName != null)
            {
                query = query.Where(x => x.FirstName.ToLower().Contains(search.FirstName.ToLower())); 
            }
            if (search.LastName != null)
            {
                query = query.Where(x => x.LastName.ToLower().Contains(search.LastName.ToLower()));
            }
            if (search.Email != null)
            {
                query = query.Where(x => x.Email.ToLower().Contains(search.Email.ToLower()));
            }
            if (search.Phone != null)
            {
                query = query.Where(x => x.PhoneNumber.Contains(search.Phone));
            }
            if (search.DateOfBirthFrom != null)
            {
                query = query.Where(x => x.DateOfBirth > search.DateOfBirthFrom);
            }
            if (search.DateOfBirthTo != null)
            {
                query = query.Where(x => x.DateOfBirth < search.DateOfBirthTo);
            }

            return query.ToPagedResponse(search, x => new ReadUserDto
            {
                Id = x.Id,
                Fullname = x.FirstName + " " + x.LastName,
                Email = x.Email,
                DateOfBirth = x.DateOfBirth,
                Gender = x.Gender.Name,
                PhoneNumber = x.PhoneNumber,
                Role = x.Role.Name,
                Cars = x.Cars.Select(y => new ReadCarDto
                {
                    Id = y.Id,
                    FirstRegistration = y.FirstRegistration,
                    BrandModel = y.Model.Brand.Name + " " + y.Model.Name,
                    Color = y.Color.Name,
                    LicencePlate = y.LicencePlate,
                    NumberOfSeats = y.NumberOfSeats,
                    Restrictions = y.CarRestrictions.Select(z => new ReadRestrictionDto
                    {
                        Name =  z.Restriction.Name
                    }),
                    ImagePath = y.ImagePath,
                    Type = y.Type.Name
                }),
                Rides = x.Rides.Select(x => new ReadRideDto
                {
                    StartCity = new ReadCityDto { Id = x.Id, Name = x.StartCity.Name },
                    DestinationCity = new ReadCityDto { Id = x.Id, Name = x.EndCity.Name },
                    NumberOfAvailableSeats = x.Car.NumberOfSeats,
                    Price = x.Price,
                    StartDate = x.StartDate
                })
            });
        }
    }
}
