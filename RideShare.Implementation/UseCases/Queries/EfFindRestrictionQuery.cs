using RideShare.Application.Exceptions;
using RideShare.Application.UseCases.DTOs.Read;
using RideShare.Application.UseCases.Queries;
using RideShare.DataAccess;
using RideShare.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Implementation.UseCases.Queries
{
    public class EfFindRestrictionQuery : IFindRestrictionQuery
    {
        private readonly RideshareContext _context;

        public EfFindRestrictionQuery(RideshareContext context)
        {
            _context = context;
        }

        public int Id => 72;

        public string Name => "Find restriction using Entity Framework";

        public ReadRestrictionDto Execute(int search)
        {
            var restriction = _context.Restrictions.Find(search);

            if (restriction == null)
            {
                throw new EntityNotFoundException(search, nameof(Restriction));
            }

            var read = new ReadRestrictionDto
            {
                Name = restriction.Name
            };

            return read;

        }
    }
}
