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
    public class EfCreateColorCommand : ICreateColorCommand
    {
        private readonly RideshareContext _context;
        private readonly CreateColorValidator _validator;

        public EfCreateColorCommand(RideshareContext context, CreateColorValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 50;

        public string Name => "Create color using Entity Framework";

        public void Execute(CreateNameOnlyDto request)
        {
            _validator.ValidateAndThrow(request);

            Color color = new Color
            {
                Name = request.Name
            };

            _context.Colors.Add(color);

            _context.SaveChanges();
        }
    }
}
