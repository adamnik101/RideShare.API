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
    public class EfDeleteRestrictionCommand : IDeleteRestrictionCommand
    {
        private readonly RideshareContext _context;
        private readonly DeleteRestrictionValidator _validator;
        public EfDeleteRestrictionCommand(RideshareContext context, DeleteRestrictionValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 71;

        public string Name => "Delete restriction using Entity Framework";

        public void Execute(int request)
        {
            _validator.ValidateAndThrow(request);

            var restriction = _context.Restrictions.WhereActive().FirstOrDefault(x => x.Id == request);

            restriction.DeletedAt = DateTime.Now;
            restriction.IsDeleted = true;
            restriction.IsActive = false;

            _context.SaveChanges();
        }
    }
}
