using FluentValidation;
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
    public class EfCreateRestrictionCommand : ICreateRestrictionCommand
    {
        private readonly RideshareContext _context;
        private readonly CreateRestrictionValidator _validator;

        public EfCreateRestrictionCommand(RideshareContext context, CreateRestrictionValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public int Id => 70;

        public string Name => "Create restriction using Entity Framework";

        public void Execute(CreateNameOnlyDto request)
        {
            _validator.ValidateAndThrow(request);

            var restriction = new Restriction
            {
                Name = request.Name
            };

            _context.Restrictions.Add(restriction);
            _context.SaveChanges();
        }
    }
}
