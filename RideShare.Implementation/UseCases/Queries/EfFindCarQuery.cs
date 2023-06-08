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
    public class EfFindCarQuery : IFindCarQuery
    {
        private readonly RideshareContext _context;
        private readonly IApplicationActor _actor;

        public EfFindCarQuery(RideshareContext context, IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }

        public int Id => 60;

        public string Name => "Find user car using Entity Framework";

        public ReadCarDto Execute(int search)
        {
            var userCar = _context.Cars.Include(x => x.Owner)
                                        .Include(x => x.Color)
                                        .Include(x => x.Type)
                                        .Include(x => x.Model)
                                            .ThenInclude(x => x.Brand)
                .Where(x => x.OwnerId == _actor.Id)
                .WhereActive()
                .FirstOrDefault(x => x.Id == search);

            if (userCar == null)
            {
                throw new EntityNotFoundException(search, nameof(Car));
            }

            ReadCarDto car = new ReadCarDto
            {
                Owner = _actor.Fullname,
                ModelBrand = userCar.Model.Name + " " + userCar.Model.Brand.Name,
                Color = userCar.Color.Name,
                Type = userCar.Type.Name,
                LicencePlate = userCar.LicencePlate,
                FirstRegistration = userCar.FirstRegistration,
                NumberOfSeats = userCar.NumberOfSeats
            };

            return car;
        }
    }
}
