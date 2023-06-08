using RideShare.Application.Exceptions;
using RideShare.Application.UseCases.DTOs.Read;
using RideShare.Application.UseCases.Queries;
using RideShare.DataAccess;
using RideShare.Domain.Entities;
using RideShare.Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Implementation.UseCases.Queries
{
    public class EfFindModelQuery : IFindModelQuery
    {
        private readonly RideshareContext _context;
        public int Id => 10;

        public string Name => "Find model using Entity Framework";

        public ReadModelDto Execute(int search)
        {
            var modelFound = _context.Models.WhereActive().FirstOrDefault(x => x.Id == search);

            if(modelFound == null)
            {
                throw new EntityNotFoundException(search, nameof(Model));
            }

            var model = new ReadModelDto
            {
                Id = modelFound.Id,
                Name = modelFound.Name
            };

            return model;
        }
    }
}
