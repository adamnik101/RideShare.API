using Newtonsoft.Json.Linq;
using RideShare.Application.UseCases.DTOs;
using RideShare.Application.UseCases.Queries.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Implementation.Extensions
{
    public static class QueryableExtensions
    {
        public static PagedResponse<Tdto> ToPagedResponse<TEntity, Tdto>
            (this IQueryable<TEntity> query,
             PagedSearch search,
             Expression<Func<TEntity, Tdto>> conversion)
            where Tdto : class
            where TEntity : class
        {
            if (search.PerPage <= 0)
            {
                search.PerPage = 10;
            }

            if (search.Page <= 0)
            {
                search.Page = 1;
            }
            var skip = (search.Page - 1) * search.PerPage;

            return new PagedResponse<Tdto>
            {
                TotalCount = query.Count(),
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                Items = query.Skip(skip)
                             .Take(search.PerPage)
                             .Select(conversion)
                             .ToList()
            };
        }
        
    }
}
