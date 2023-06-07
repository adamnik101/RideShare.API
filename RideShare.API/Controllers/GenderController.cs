using Microsoft.AspNetCore.Mvc;
using RideShare.Application.UseCaseHandling.Command;
using RideShare.Application.UseCaseHandling.Query;
using RideShare.Application.UseCases.Queries;
using RideShare.Application.UseCases.Queries.Searches;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RideShare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IQueryHandler _queryHandler;

        public GenderController(IQueryHandler queryHandler)
        {
            _queryHandler = queryHandler;
        }

        // GET: api/<GenderController>
        [HttpGet]
        public IActionResult Get([FromServices] IReadGendersQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, ""));
        }
    }
}
