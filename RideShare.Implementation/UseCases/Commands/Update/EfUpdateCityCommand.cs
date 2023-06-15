using FluentValidation;
using RideShare.Application.Exceptions;
using RideShare.Application.UseCases.Commands.Update;
using RideShare.Application.UseCases.DTOs;
using RideShare.DataAccess;
using RideShare.Domain.Entities;
using RideShare.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Implementation.UseCases.Commands.Update
{
    public class EfUpdateCityCommand : IUpdateCityCommand
    {
        private readonly RideshareContext _context;
        private readonly UpdateNameValidator _validator;

        public EfUpdateCityCommand(RideshareContext context, UpdateNameValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 341;

        public string Name => "Update city using Entity Framework";

        public void Execute(UpdateNameDto request)
        {
            _validator.ValidateAndThrow(request);
            var id = request.Id;
            var name = request.Name;

            var city = _context.Cities.Find(id);

            if(city == null) 
            {
                throw new EntityNotFoundException(id, nameof(City));
            }

            city.Name = name;
            city.ModifiedAt = DateTime.UtcNow;

            _context.SaveChanges();
        }
    }
}
