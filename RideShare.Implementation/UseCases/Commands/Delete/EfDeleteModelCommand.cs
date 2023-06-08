using FluentValidation;
using RideShare.Application.Exceptions;
using RideShare.Application.UseCases.Commands.Delete;
using RideShare.DataAccess;
using RideShare.Domain.Entities;
using RideShare.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Implementation.UseCases.Commands.Delete
{
    public class EfDeleteModelCommand : IDeleteModelCommand
    {
        private readonly RideshareContext _context;
        private readonly DeleteModelValidator _validator;
        public EfDeleteModelCommand(RideshareContext context, DeleteModelValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 8;

        public string Name => "Delete model using Entity Framework";

        public void Execute(int request)
        {
            _validator.ValidateAndThrow(request);

            var model = _context.Models.Find(request);

            model.IsDeleted = true;
            model.DeletedAt = DateTime.UtcNow;
            model.IsActive = false;

            _context.SaveChanges();
        }
    }
}
