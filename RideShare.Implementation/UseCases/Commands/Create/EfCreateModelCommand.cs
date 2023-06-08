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
    public class EfCreateModelCommand : ICreateModelCommand
    {
        private readonly RideshareContext _context;
        private readonly CreateModelValidator _validator;

        public EfCreateModelCommand(RideshareContext context, CreateModelValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 6;

        public string Name => "Create new model using Entity Framework";

        public void Execute(CreateModelDto request)
        {
            _validator.ValidateAndThrow(request);

            Model model = new Model
            {
                Name = request.Name,
                BrandId = request.BrandId
            };

            _context.Models.Add(model);
            _context.SaveChanges();
        }
    }
}
