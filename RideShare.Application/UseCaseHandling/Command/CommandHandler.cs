using RideShare.Application.Exceptions;
using RideShare.Application.Logging;
using RideShare.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Application.UseCaseHandling.Command
{
    public class CommandHandler : ICommandHandler
    {
        private readonly IApplicationActor _actor;
        private readonly IUseCaseLogger _logger;

        public CommandHandler(IApplicationActor actor, IUseCaseLogger logger)
        {
            _actor = actor;
            _logger = logger;
        }

        public void HandleCommand<TRequest>(ICommand<TRequest> command, TRequest data)
        {
            if (!_actor.AllowedUseCases.Contains(command.Id))
            {
                throw new UnauthorizedUseCaseException(_actor.Fullname, command.Name);
            }

            _logger.Add(new UseCaseLogEntry
            {
                Actor = _actor.Fullname,
                ActorId = _actor.Id,
                UseCaseName = command.Name,
                Data = data
            });

            command.Execute(data);
        }
    }
}
