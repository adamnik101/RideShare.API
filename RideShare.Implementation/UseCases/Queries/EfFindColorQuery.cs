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
    public class EfFindColorQuery : IFindColorQuery
    {
        private readonly RideshareContext _context;

        public EfFindColorQuery(RideshareContext context)
        {
            _context = context;
        }

        public int Id => 51;

        public string Name => "Find color using Entity Framework";

        public ReadColorDto Execute(int search)
        {
            var colorFound = _context.Colors.Find(search);

            if(colorFound == null)
            {
                throw new EntityNotFoundException(search, nameof(Color));
            }

            var color = new ReadColorDto
            {
                Name = colorFound.Name,
            };

            return color;
        }
    }
}
