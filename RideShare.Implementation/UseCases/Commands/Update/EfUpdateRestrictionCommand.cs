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
    public class EfUpdateRestrictionCommand : IUpdateRestrictionCommand
    {
        private readonly RideshareContext _context;
        private readonly UpdateNameValidator _validator;

        public EfUpdateRestrictionCommand(RideshareContext context, UpdateNameValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 345;

        public string Name => "Update restriction using Entity Framework";

        public void Execute(UpdateNameDto request)
        {
            _validator.ValidateAndThrow(request);

            var id = request.Id;
            var name = request.Name;

            var restriction = _context.Restrictions.Find(id);

            if(restriction == null)
            {
                throw new EntityNotFoundException(id, nameof(Restriction));
            }

            restriction.Name = name; 
            restriction.ModifiedAt = DateTime.Now;

            _context.SaveChanges();


        }
    }
}
