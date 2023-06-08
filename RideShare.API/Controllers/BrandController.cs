using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RideShare.Application.UseCaseHandling;
using RideShare.Application.UseCaseHandling.Command;
using RideShare.Application.UseCaseHandling.Query;
using RideShare.Application.UseCases.Commands.Create;
using RideShare.Application.UseCases.Commands.Delete;
using RideShare.Application.UseCases.DTOs.Create;
using RideShare.Application.UseCases.Queries;
using RideShare.Application.UseCases.Queries.Searches;
using RideShare.DataAccess;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RideShare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BrandController : ControllerBase
    {
        private readonly IQueryHandler _queryHandler;
        private readonly ICommandHandler _commandHandler;

        public BrandController(IQueryHandler queryHandler, ICommandHandler commandHandler)
        {
            _queryHandler = queryHandler;
            _commandHandler = commandHandler;
        }

        // GET: api/<BrandController>
        [HttpGet]
        public IActionResult Get([FromQuery] SearchName data, [FromServices] IReadBrandsQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, data));
        }
        [HttpGet("{id}/models")]
        public IActionResult GetBrandModels (int id, [FromServices] IReadBrandModelsQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }
        // GET api/<BrandController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IFindBrandQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }

        // POST api/<BrandController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateNameOnlyDto dto, [FromServices] ICreateBrandCommand command)
        {
            _commandHandler.HandleCommand(command, dto); 
            return StatusCode(201);
        }

        // PUT api/<BrandController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BrandController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteBrandCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
