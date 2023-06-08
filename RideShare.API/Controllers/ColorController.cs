using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RideShare.Application.UseCaseHandling.Command;
using RideShare.Application.UseCaseHandling.Query;
using RideShare.Application.UseCases.Commands.Create;
using RideShare.Application.UseCases.Commands.Delete;
using RideShare.Application.UseCases.DTOs.Create;
using RideShare.Application.UseCases.Queries;
using RideShare.Application.UseCases.Queries.Searches;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RideShare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ColorController : ControllerBase
    {
        private readonly IQueryHandler _queryHandler;
        private readonly ICommandHandler _commandHandler;

        public ColorController(IQueryHandler queryHandler, ICommandHandler commandHandler)
        {
            _queryHandler = queryHandler;
            _commandHandler = commandHandler;
        }

        // GET: api/<ColorController>
        [HttpGet]
        public IActionResult Get([FromQuery] SearchName data, [FromServices] IReadColorsQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, data));
        }

        // GET api/<ColorController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IFindColorQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }

        // POST api/<ColorController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateNameOnlyDto data, [FromServices] ICreateColorCommand command)
        {
            _commandHandler.HandleCommand(command, data);
            return StatusCode(201);
        }

        // PUT api/<ColorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {

            return Ok();
        }

        // DELETE api/<ColorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteColorCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
