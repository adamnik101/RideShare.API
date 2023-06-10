using Microsoft.EntityFrameworkCore;
using RideShare.Application;
using RideShare.Application.Exceptions;
using RideShare.Application.UseCases.DTOs.Read;
using RideShare.Application.UseCases.Queries;
using RideShare.Application.UseCases.Queries.Searches;
using RideShare.DataAccess;
using RideShare.Domain.Entities;
using RideShare.Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Implementation.UseCases.Queries
{
    public class EfReadUserCarsQuery : IReadUserCarsQuery
    {
        private readonly RideshareContext _context;
        private readonly IApplicationActor _actor;

        public EfReadUserCarsQuery(RideshareContext context, IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }
        public int Id => 600;

        public string Name => "Read user cars using Entity Framework";

        public IEnumerable<ReadCarDto> Execute(int id)
        {
            var userCars = _context.Cars.Include(x => x.Owner)
                                        .Include(x => x.Color)
                                        .Include(x => x.Type)
                                        .Include(x => x.Model)
            .ThenInclude(x => x.Brand)
            .Include(x => x.CarRestrictions)
                    .ThenInclude(x => x.Restriction)
                .Where(x => x.OwnerId == _actor.Id && x.OwnerId == id)
                .WhereActive();

            if(!userCars.Any())
            {
                throw new EntityNotFoundException(id, nameof(User));
            }
            
            var cars = userCars.Select(x => new ReadCarDto
            {
                Owner = _actor.Fullname,
                ModelBrand = x.Model.Brand.Name + " " + x.Model.Name,
                Color = x.Color.Name,
                Type = x.Type.Name,
                LicencePlate = x.LicencePlate,
                FirstRegistration = x.FirstRegistration,
                NumberOfSeats = x.NumberOfSeats,
                ImagePath = x.ImagePath,
                Restrictions = x.CarRestrictions.Select(x => new ReadRestrictionDto
                {
                    Name = x.Restriction.Name
                })
            });

            return cars;
        }
    }
}
