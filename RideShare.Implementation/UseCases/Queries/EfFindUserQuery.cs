using Microsoft.EntityFrameworkCore;
using RideShare.Application;
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
    public class EfFindUserQuery : IFindUserQuery
    {
        private readonly RideshareContext _context;
        private readonly IApplicationActor _actor;

        public EfFindUserQuery(RideshareContext context, IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }

        public int Id => 555;

        public string Name => "Find user using Entity Framework";

        public ReadUserDto Execute(int search)
        {
            var userExists = _context.Users.Include(x => x.Rides).ThenInclude(x => x.StartCity).Include(x => x.Rides).ThenInclude(x => x.EndCity).Include(x => x.Cars).ThenInclude(x => x.Color).Include(x => x.Cars).ThenInclude(x => x.Type).Include(x => x.Cars).ThenInclude(x => x.CarRestrictions).ThenInclude(x => x.Restriction).Include(x => x.Cars).ThenInclude(x => x.Model).ThenInclude(x => x.Brand).Include(x => x.Gender).Include(x => x.Role).WhereActive().FirstOrDefault(x => x.Id == search && x.Id == _actor.Id);

            if(userExists == null)
            {
                throw new EntityNotFoundException(search, nameof(User));
            }

            var user = new ReadUserDto
            {
                Id = _actor.Id,
                Fullname = _actor.Fullname,
                Email = userExists.Email,
                DateOfBirth = userExists.DateOfBirth,
                Gender = userExists.Gender.Name,
                PhoneNumber = userExists.PhoneNumber,
                Role = userExists.Role.Name,
                Cars = userExists.Cars.Select(x => new ReadCarDto
                {
                    Id = x.Id,
                    FirstRegistration = x.FirstRegistration,
                    BrandModel = x.Model.Brand.Name + " " + x.Model.Name,
                    Color = x.Color.Name,
                    LicencePlate = x.LicencePlate,
                    NumberOfSeats = x.NumberOfSeats,
                    Restrictions = x.CarRestrictions.Select(x => new ReadRestrictionDto
                    {
                        Name = x.Restriction.Name
                    }),
                    ImagePath = x.ImagePath,
                    Type = x.Type.Name                    
                }),
                Rides = userExists.Rides.Select(x => new ReadRideDto
                {
                    StartCity = new ReadCityDto { Id = x.Id, Name = x.StartCity.Name },
                    DestinationCity = new ReadCityDto { Id = x.Id, Name = x.EndCity.Name },
                    NumberOfAvailableSeats = x.Car.NumberOfSeats,
                    Price = x.Price,
                    StartDate = x.StartDate
                })
            };

            return user;
        }
    }
}
