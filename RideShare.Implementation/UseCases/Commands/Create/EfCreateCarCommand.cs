using FluentValidation;
using RideShare.Application;
using RideShare.Application.UseCases.Commands.Create;
using RideShare.Application.UseCases.DTOs.Create;
using RideShare.DataAccess;
using RideShare.Domain.Entities;
using RideShare.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Implementation.UseCases.Commands.Create
{
    public class EfCreateCarCommand : ICreateCarCommand
    {
        private readonly RideshareContext _context;
        private readonly CreateCarValidator _validator;
        private readonly IApplicationActor _actor;

        public EfCreateCarCommand(RideshareContext context, CreateCarValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }

        public int Id => 18;

        public string Name => "Create car using Entity Framework";

        public void Execute(CreateCarDto request)
        {
            _validator.ValidateAndThrow(request);

            Car car = new Car
            {
                ColorId = request.ColorId,
                ModelId = request.ModelId,
                FirstRegistration = request.FirstRegistration,
                LicencePlate = request.LicencePlate,
                NumberOfSeats = request.NumberOfSeats,
                OwnerId = _actor.Id,
                TypeId = request.TypeId
            };

            _context.Cars.Add(car);

            _context.SaveChanges();
        }
    }
}
