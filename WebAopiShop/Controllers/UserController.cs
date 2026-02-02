using DTOs;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Text.Json;
using WebAopiShop;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShop.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService service;
        ILogger logger;

        public UserController(IUserService service, ILogger logger)
        {
            this.service = service;
            this.logger = logger;
        }

        

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            UserDTO user = await service.GetUserById(id);
            if (user == null)
            {
                return NoContent();
            }
            return Ok(user);
        }

        // POST api/<UsersController>
        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> Login([FromBody] User val)
        {
            UserDTO user = await service.LogIn(val);
            if (user == null)
            {
                return NoContent();
            }
            logger.LogInformation(user.UserName,user.FirstName,user.LastName);
            return Ok(user);
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserDTO>> Register([FromBody] User val)
        {
            UserDTO user = await service.AddUser(val);
            if (user == null)
            {
                return BadRequest("Password too weak");
            }
            return CreatedAtAction(nameof(Get), new {user.UserId},user);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User value)
        {
           bool success = await service.UpdateUser(value,id);
           if(!success)
            {
                return BadRequest("Password too weak");
            }
           return Ok(value);
        }

    }
}
