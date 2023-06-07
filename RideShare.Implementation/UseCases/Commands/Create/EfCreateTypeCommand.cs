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
using Type = RideShare.Domain.Entities.Type;

namespace RideShare.Implementation.UseCases.Commands.Create
{
    public class EfCreateTypeCommand : ICreateTypeCommand
    {
        private readonly CreateTypeValidator _validator;
        private readonly RideshareContext _context;

        public EfCreateTypeCommand(CreateTypeValidator validator, RideshareContext context)
        {
            _validator = validator;
            _context = context;
        }

        public int Id => 15;

        public string Name => "Create car type using Entity Framework";

        public void Execute(CreateNameOnlyDto request)
        {
            _validator.ValidateAndThrow(request);

            Type type = new Type
            {
                Name = request.Name
            };

            _context.Types.Add(type);

            _context.SaveChanges();
        }
    }
}
