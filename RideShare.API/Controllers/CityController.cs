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
    public class CityController : ControllerBase
    {
        // GET: api/<CityController>
        [HttpGet]
        public IActionResult Get([FromQuery] SearchName data, [FromServices] IQueryHandler handler, [FromServices] IReadCitiesQuery query)
        {
            return Ok(handler.HandleQuery(query, data));
        }

        // GET api/<CityController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IQueryHandler handler, [FromServices] IFindCityQuery query)
        {
            return Ok(handler.HandleQuery(query, id));
        }

        // POST api/<CityController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateNameOnlyDto data, [FromServices] ICommandHandler handler, [FromServices] ICreateCityCommand command)
        {
            handler.HandleCommand(command, data);
            return StatusCode(201);
        }

        // PUT api/<CityController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CityController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] ICommandHandler handler, [FromServices] IDeleteCityCommand command)
        {
            handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
