using FluentValidation;
using RideShare.Application.Exceptions;
using RideShare.Application.UseCases.Commands.Delete;
using RideShare.DataAccess;
using RideShare.Domain.Entities;
using RideShare.Implementation.Extensions;
using RideShare.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Implementation.UseCases.Commands.Delete
{
    public class EfDeleteTypeCommand : IDeleteTypeCommand
    {
        private readonly RideshareContext _context;
        private readonly DeleteTypeValidator _validator;

        public EfDeleteTypeCommand(RideshareContext context, DeleteTypeValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 200;

        public string Name => "Delete type using Entity Framework";

        public void Execute(int request)
        {
            _validator.ValidateAndThrow(request);

            var type = _context.Types.WhereActive().FirstOrDefault(x => x.Id == request);

            type.IsDeleted = true;
            type.IsActive = false;
            type.DeletedAt = DateTime.Now;

            _context.SaveChanges();
        }
    }
}
