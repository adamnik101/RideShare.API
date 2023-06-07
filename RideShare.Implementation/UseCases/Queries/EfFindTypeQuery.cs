using RideShare.Application.Exceptions;
using RideShare.Application.UseCases.DTOs.Read;
using RideShare.Application.UseCases.Queries;
using RideShare.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = RideShare.Domain.Entities.Type;

namespace RideShare.Implementation.UseCases.Queries
{
    public class EfFindTypeQuery : IFindTypeQuery
    {
        private readonly RideshareContext _context;

        public EfFindTypeQuery(RideshareContext context)
        {
            _context = context;
        }

        public int Id => 17;

        public string Name => "Find car type using Entity Framework";

        public ReadTypeDto Execute(int search)
        {
            var typeExists = _context.Types.Find(search);
            
            if (typeExists == null)
            {
                throw new EntityNotFoundException(search, nameof(Type));
            }

            var type = new ReadTypeDto
            {
                Name = typeExists.Name
            };

            return type;
        }
    }
}
