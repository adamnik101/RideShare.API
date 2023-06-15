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
    public class CitiesController : ControllerBase
    {
        private readonly IQueryHandler _queryHandler;
        private readonly ICommandHandler _commandHandler;

        public CitiesController(IQueryHandler queryHandler, ICommandHandler commandHandler)
        {
            _queryHandler = queryHandler;
            _commandHandler = commandHandler;
        }

        // GET: api/<CityController>
        [HttpGet]
        public IActionResult Get([FromQuery] SearchName data, [FromServices] IReadCitiesQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, data));
        }

        // GET api/<CityController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IFindCityQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }

        // POST api/<CityController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateNameOnlyDto data, [FromServices] ICreateCityCommand command)
        {
            _commandHandler.HandleCommand(command, data);
            return StatusCode(201);
        }

        // PUT api/<CityController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateNameDto data, [FromServices] IUpdateCityCommand command)
        {
            data.Id = id;
            _commandHandler.HandleCommand(command, data);

            return NoContent();
        }

        // DELETE api/<CityController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCityCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
