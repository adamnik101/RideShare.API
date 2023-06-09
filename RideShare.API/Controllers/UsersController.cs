﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RideShare.Application.UseCaseHandling.Command;
using RideShare.Application.UseCaseHandling.Query;
using RideShare.Application.UseCases.Commands.Create;
using RideShare.Application.UseCases.DTOs.Create;
using RideShare.Application.UseCases.Queries;
using RideShare.Application.UseCases.Queries.Searches;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RideShare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly ICommandHandler _commandHandler;
        private readonly IQueryHandler _queryHandler;

        public UsersController(ICommandHandler commandHandler, IQueryHandler queryHandler)
        {
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get([FromQuery] SearchUser data, [FromServices] IReadUsersQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query,data));
        }
        // GET: api/user/1/cars>

        [HttpGet("{id}/cars")]
        public IActionResult GetUserCars(int id, [FromServices] IReadUserCarsQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }
        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IFindUserQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }

        // POST api/<UserController>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult RegisterUser ([FromBody] RegisterUserDto data, [FromServices] IRegisterUserCommand command)
        {

            _commandHandler.HandleCommand(command, data);
            return StatusCode(201);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
