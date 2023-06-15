using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RideShare.Application.UseCaseHandling.Command;
using RideShare.Application.UseCaseHandling.Query;
using RideShare.Application.UseCases.Commands.Create;
using RideShare.Application.UseCases.Commands.Delete;
using RideShare.Application.UseCases.Commands.Update;
using RideShare.Application.UseCases.DTOs;
using RideShare.Application.UseCases.DTOs.Create;
using RideShare.Application.UseCases.Queries;
using RideShare.Application.UseCases.Queries.Searches;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RideShare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RestrictionsController : ControllerBase
    {
        private readonly ICommandHandler _commandHandler;
        private readonly IQueryHandler _queryHandler;

        public RestrictionsController(ICommandHandler commandHandler, IQueryHandler queryHandler)
        {
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }

        // GET: api/<RestrictionController>
        [HttpGet]
        public IActionResult Get([FromQuery] SearchName data, [FromServices] IReadRestrictionQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, data));
        }

        // GET api/<RestrictionController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IFindRestrictionQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }

        // POST api/<RestrictionController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateNameOnlyDto data, [FromServices] ICreateRestrictionCommand command)
        {
            _commandHandler.HandleCommand(command, data);
            return StatusCode(201);
        }

        // PUT api/<RestrictionController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateNameDto data, [FromServices] IUpdateRestrictionCommand command)
        {
            data.Id = id;
            _commandHandler.HandleCommand(command, data);
            return NoContent();
        }

        // DELETE api/<RestrictionController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteRestrictionCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
