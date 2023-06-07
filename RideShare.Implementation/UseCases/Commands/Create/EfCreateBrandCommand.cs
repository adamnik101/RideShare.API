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
    public class EfCreateBrandCommand : ICreateBrandCommand
    {
        private readonly RideshareContext _context;
        private readonly OnlyNameValidator _validator;

        public EfCreateBrandCommand(RideshareContext context, OnlyNameValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 1;

        public string Name => "Create brand using Entity Framework";

        public void Execute(CreateNameOnlyDto request)
        {
            _validator.ValidateAndThrow(request);

            var brandExists = _context.Brands.Any(x => x.Name == request.Name);

            if(brandExists)
            {
                throw new EntityAlreadyExistsException(request.Name, nameof(Brand));
            }

            Brand brand = new Brand
            {
                Name = request.Name
            };

            _context.Brands.Add(brand);
            _context.SaveChanges();
        }
    }
}
