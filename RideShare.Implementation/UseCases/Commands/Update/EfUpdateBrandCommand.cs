using FluentValidation;
using RideShare.Application.Exceptions;
using RideShare.Application.UseCases.Commands.Update;
using RideShare.Application.UseCases.DTOs;
using RideShare.DataAccess;
using RideShare.Domain.Entities;
using RideShare.Implementation.Validators;
using System;

namespace RideShare.Implementation.UseCases.Commands.Update
{
    public class EfUpdateBrandCommand : IUpdateBrandCommand
    {
        private readonly RideshareContext _context;
        private readonly UpdateNameValidator _validator;

        public EfUpdateBrandCommand(RideshareContext context, UpdateNameValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 340;
        public string Name => "Update brand using Entity Framework";

        public void Execute(UpdateNameDto data)
        {
            _validator.ValidateAndThrow(data);

            var id = data.Id;
            var name = data.Name;

            var brand = _context.Brands.Find(id);
            
            if(brand == null)
            {
                throw new EntityNotFoundException(id, nameof(Brand));
            }

            brand.Name = name;
            brand.ModifiedAt = DateTime.Now;

            _context.SaveChanges();
        }
    }
}