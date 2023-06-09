﻿using Microsoft.EntityFrameworkCore;
using RideShare.Application;
using RideShare.Application.UseCases.DTOs;
using RideShare.Application.UseCases.DTOs.Read;
using RideShare.Application.UseCases.Queries;
using RideShare.Application.UseCases.Queries.Searches;
using RideShare.DataAccess;
using RideShare.Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Implementation.UseCases.Queries
{
    public class EfReadCarsQuery : IReadCarsQuery
    {
        private readonly RideshareContext _context;
        private readonly IApplicationActor _actor;

        public EfReadCarsQuery(RideshareContext context, IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }

        public int Id => 61;

        public string Name => "Read user cars using Entity Framework";

        public PagedResponse<ReadCarDto> Execute(SearchCarDto search)
        {
            var query = _context.Cars.Include(x => x.Owner)
                                         .Include(x => x.Color)
                                         .Include(x => x.Type)
                                         .Include(x => x.Model)
                                             .ThenInclude(x => x.Brand)
                 .Where(x => x.OwnerId == _actor.Id).WhereActive().AsQueryable();

            if(search.Model != null)
            {
                query = query.Where(x => x.Model.Name.ToLower().Contains(search.Model.ToLower()));
            }

            if (search.Type != null)
            {
                query = query.Where(x => x.Type.Name.ToLower().Contains(search.Type.ToLower()));
            }

            if (search.Brand != null)
            {
                query = query.Where(x => x.Model.Brand.Name.ToLower().Contains(search.Brand.ToLower()));
            }

            if (search.Color != null)
            {
                query = query.Where(x => x.Color.Name.ToLower().Contains(search.Color.ToLower()));
            }

            return query.ToPagedResponse(search, x => new ReadCarDto
            {
                Id = x.Id,
                Owner = _actor.Fullname,
                BrandModel = x.Model.Brand.Name + " " + x.Model.Name,
                Color = x.Color.Name,
                Type = x.Type.Name,
                LicencePlate = x.LicencePlate,
                FirstRegistration = x.FirstRegistration,
                NumberOfSeats = x.NumberOfSeats,
                ImagePath = x.ImagePath,
                Restrictions = x.CarRestrictions.Select(x => new ReadRestrictionDto
                {
                    Id = x.Restriction.Id,
                    Name = x.Restriction.Name
                })
            });
        }
    }
}
