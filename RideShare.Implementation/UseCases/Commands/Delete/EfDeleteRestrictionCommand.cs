using FluentValidation;
using Microsoft.EntityFrameworkCore;
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
        public EfDeleteRestrictionCommand(RideshareContext context)
        {
            _context = context;
        }

        public int Id => 71;

        public string Name => "Delete restriction using Entity Framework";

        public void Execute(int request)
        {

            var restriction = _context.Restrictions.Include(x => x.CarRestrictions).FirstOrDefault(x => x.Id == request && x.IsActive);

            if(restriction == null)
            {
                throw new EntityNotFoundException(request, nameof(Restriction));
            }
            if(restriction.CarRestrictions.Any())
            {
                throw new InvalidOperationException("Cannot delete restriction. There is a user car associated with it.");
            }

            restriction.DeletedAt = DateTime.Now;
            restriction.IsDeleted = true;
            restriction.IsActive = false;

            _context.SaveChanges();
        }
    }
}
