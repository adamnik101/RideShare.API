using FluentValidation;
using RideShare.Application.Exceptions;
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
    public class EfCreateCityCommand : ICreateCityCommand
    {
        private readonly RideshareContext _context;
        private readonly OnlyNameValidator _validator;

        public EfCreateCityCommand(RideshareContext context, OnlyNameValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 11;

        public string Name => "Create new city using Entity Framework";

        public void Execute(CreateNameOnlyDto request)
        {
            _validator.ValidateAndThrow(request);

            var cityExists = _context.Cities.Any(x => x.Name.ToLower().Contains(request.Name.ToLower()));

            if (cityExists)
            {
                throw new EntityAlreadyExistsException(request.Name, nameof(City));
            }
            City city = new City
            {
                Name = request.Name
            };

            _context.Cities.Add(city);
            _context.SaveChanges();
            //zavrsio si grad, modele i brendove. Ostalo ti je jos update za to sve
            //napraviti komande za to
            //onda odraditi paginaciju
            //onda odraditi glavne funkcionalnosti
        }
    }
}
