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
    public class CarController : ControllerBase
    {
        private readonly IQueryHandler _queryHandler;
        private readonly ICommandHandler _commandHandler;

        public CarController(IQueryHandler queryHandler, ICommandHandler commandHandler)
        {
            _queryHandler = queryHandler;
            _commandHandler = commandHandler;
        }

        // GET: api/<CarController>
        [HttpGet]
        public IActionResult Get([FromQuery] SearchCarDto data, [FromServices] IReadCarsQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query,data));
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IFindCarQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query,id));
        }

        // POST api/<CarController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateCarDto data, [FromServices] ICreateCarCommand command)
        {
            _commandHandler.HandleCommand(command, data);
            return StatusCode(201);
        }

        // PUT api/<CarController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCarCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
