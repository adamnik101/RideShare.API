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
    public class ModelsController : ControllerBase
    {
        // GET: api/<ModelController>
        [HttpGet]
        public IActionResult Get([FromQuery] SearchName data, [FromServices] IQueryHandler handler, [FromServices] IReadModelsQuery query)
        {
            return Ok(handler.HandleQuery(query, data));
        }

        // GET api/<ModelController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IQueryHandler handler, [FromServices] IFindModelQuery query)
        {
            return Ok(handler.HandleQuery(query, id));
        }

        // POST api/<ModelController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateModelDto data, [FromServices] ICommandHandler handler, [FromServices] ICreateModelCommand command)
        {
            handler.HandleCommand(command, data);
            return StatusCode(201);
        }

        // PUT api/<ModelController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ModelController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] ICommandHandler handler, [FromServices] IDeleteModelCommand command)
        {
            handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
