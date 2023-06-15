using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RideShare.Application.UseCaseHandling.Command;
using RideShare.Application.UseCaseHandling.Query;
using RideShare.Application.UseCases.Commands.Create;
using RideShare.Application.UseCases.Commands.Delete;
using RideShare.Application.UseCases.Commands.Update;
using RideShare.Application.UseCases.DTOs.Create;
using RideShare.Application.UseCases.DTOs.Update;
using RideShare.Application.UseCases.Queries;
using RideShare.Application.UseCases.Queries.Searches;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RideShare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ModelsController : ControllerBase
    {
        private readonly IQueryHandler _queryHandler;
        private readonly ICommandHandler _commandHandler;

        public ModelsController(IQueryHandler queryHandler, ICommandHandler commandHandler)
        {
            _queryHandler = queryHandler;
            _commandHandler = commandHandler;
        }

        // GET: api/<ModelController>
        [HttpGet]
        public IActionResult Get([FromQuery] SearchName data, [FromServices] IReadModelsQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, data));
        }

        // GET api/<ModelController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IFindModelQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }

        // POST api/<ModelController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateModelDto data, [FromServices] ICreateModelCommand command)
        {
            _commandHandler.HandleCommand(command, data);
            return StatusCode(201);
        }

        // PUT api/<ModelController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateModel data, [FromServices] IUpdateModelCommand command)
        {
            data.Id = id;
            _commandHandler.HandleCommand(command, data);

            return NoContent();
        }

        // DELETE api/<ModelController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteModelCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
