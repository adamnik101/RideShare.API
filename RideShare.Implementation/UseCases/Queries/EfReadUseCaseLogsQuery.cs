﻿using FluentValidation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RideShare.Application;
using RideShare.Application.UseCases.DTOs;
using RideShare.Application.UseCases.DTOs.Read;
using RideShare.Application.UseCases.Queries;
using RideShare.Application.UseCases.Queries.Searches;
using RideShare.DataAccess;
using RideShare.Domain.Entities;
using RideShare.Implementation.Extensions;
using RideShare.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Implementation.UseCases.Queries
{
    public class EfReadUseCaseLogsQuery : IReadUseCaseLogsQuery
    {
        private readonly RideshareContext _context;
        private readonly SearchUseCaseValidator _validator;

        public EfReadUseCaseLogsQuery(RideshareContext context, SearchUseCaseValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 999;

        public string Name => "Read use case logs using Entity Framework";

        public PagedResponse<ReadUseCaseLogDto> Execute(SearchUseCaseLog search)
        {
            _validator.ValidateAndThrow(search);

            var query = _context.LogEntries.WhereActive().AsQueryable();

            if (search.Actor != null)
            {
                query = query.Where(x => x.Actor.ToLower().Contains(search.Actor));
            }

            if (search.UseCaseName != null)
            {
                query = query.Where(x => x.UseCaseName.ToLower().Contains(search.UseCaseName.ToLower()));
            }

            if(search.DateFrom != null)
            {
                query = query.Where(x => x.CreatedAt > search.DateFrom);
            }

            if(search.DateTo != null)
            {
                query = query.Where(x => x.CreatedAt < search.DateTo);
            }
            
            return query.ToPagedResponse(search, x => new ReadUseCaseLogDto
            {
                Id = x.Id,
                UseCaseName = x.UseCaseName,
                Actor = x.Actor,
                ExecutedAt = x.CreatedAt,
                Data = DeserializeUseCaseData(JToken.Parse(x.UseCaseData))
            });
        }
        private static object DeserializeUseCaseData(JToken dataToken)
        {
            if (dataToken.Type == JTokenType.Object)
            {
                return dataToken.ToObject<Dictionary<string, string>>();
            }
            return dataToken.Value<int>();
        }
    }
}
