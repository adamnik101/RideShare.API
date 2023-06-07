using RideShare.Application.Exceptions;
using RideShare.Application.Logging;
using RideShare.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Application.UseCaseHandling.Query
{
    public class QueryHandler : IQueryHandler
    {
        private readonly IApplicationActor _actor;
        private readonly IUseCaseLogger _logger;

        public QueryHandler(IApplicationActor actor, IUseCaseLogger logger)
        {
            _actor = actor;
            _logger = logger;
        }

        public TResult HandleQuery<TSearch, TResult>(IQuery<TSearch, TResult> query, TSearch search) where TResult : class
        {
            if (!_actor.AllowedUseCases.Contains(query.Id))
            {
                throw new UnauthorizedUseCaseException(_actor.Fullname, query.Name);
            }

            _logger.Add(new UseCaseLogEntry
            {
                Actor = _actor.Fullname,
                ActorId = _actor.Id,
                Data = search,
                UseCaseName = query.Name
            });


            return query.Execute(search);
        }
    }
}
