using RideShare.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Implementation.Extensions
{
    public static class EntityExtensions
    {
        public static IQueryable<T> WhereActive<T> (this IQueryable<T> query)
            where T : Entity
        {
            return query.Where(x => x.IsActive && !x.IsDeleted);
        }
    }
}
