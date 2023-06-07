using Microsoft.EntityFrameworkCore;
using RideShare.Application;
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
    public class EfReadBrandModelsQuery : IReadBrandModelsQuery
    {
        private readonly RideshareContext _context;
        private readonly IApplicationActor _actor;

        public EfReadBrandModelsQuery(RideshareContext context, IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }
        public int Id => 201;

        public string Name => "Read brand models using Entity Framework";

        public IEnumerable<ReadModelDto> Execute(int search)
        {
            var brand = _context.Brands.Where(x => x.Id == search).Include(x => x.Models).FirstOrDefault();

            if(brand == null)
            {
                throw new EntityNotFoundException(search, nameof(Brand));
            }


            var models = brand.Models.Select(x => new ReadModelDto
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return models;
        }
    }
}
