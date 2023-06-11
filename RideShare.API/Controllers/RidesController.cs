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
    public class RidesController : ControllerBase
    {
        private readonly IQueryHandler _queryHandler;
        private readonly ICommandHandler _commandHandler;

        public RidesController(IQueryHandler queryHandler, ICommandHandler commandHandler)
        {
            _queryHandler = queryHandler;
            _commandHandler = commandHandler;
        }

        // GET: api/<RideController>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery] SearchRideDto data, [FromServices] IReadRidesQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, data));
        }

        // GET api/<RideController>/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult Get(int id, [FromServices] IFindRideQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }
        // GET api/rides/1/passengers
        [HttpGet("{id}/passengers")]
        public IActionResult GetRideUsers(int id, [FromServices] IReadRidePassengersQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }
        // POST api/<RideController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateRideDto data, [FromServices] ICreateRideCommand command)
        {
            _commandHandler.HandleCommand(command, data);
            return StatusCode(201);
        }

        // POST api/ride/1/request
        [HttpPost("{id}/request")]
        public IActionResult SendRequest(int id, [FromServices] ISendRequestCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return StatusCode(201);
        }
        // POST api/ride/1/request
        [HttpPatch("{id}/request")]
        public IActionResult UpdateRequest(int id)
        {
            //_commandHandler.HandleCommand(command, id);
            return StatusCode(201);
        }
        // PUT api/<RideController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RideController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] IDeleteRideCommand command)
        {
            _commandHandler.HandleCommand(command, id);

            return NoContent();
        }
    }
}
