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
    public class EfUpdateTypeCommand : IUpdateTypeCommand
    {
        private readonly UpdateNameValidator _validator;
        private readonly RideshareContext _context;

        public EfUpdateTypeCommand(UpdateNameValidator validator, RideshareContext context)
        {
            _validator = validator;
            _context = context;
        }

        public int Id => 343;

        public string Name => "Update car type using Entity Framework";

        public void Execute(UpdateNameDto request)
        {
            _validator.ValidateAndThrow(request);

            var id = request.Id;
            var name = request.Name;

            var type = _context.Types.Find(id);

            if(type == null)
            {
                throw new EntityNotFoundException(id, nameof(Domain.Entities.Type));
            }

            type.Name = name;
            type.ModifiedAt = DateTime.Now;

            _context.SaveChanges();

        }
    }
}
