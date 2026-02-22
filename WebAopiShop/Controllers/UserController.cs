using DTOs;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService service, ILogger<UserController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            UserDTO user = await _service.GetUserById(id);
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
            UserDTO user = await _service.LogIn(val);
            if (user == null)
            {
                return NoContent();
            }
            _logger.LogInformation($"Login successful for user: {user.Email}");
            return Ok(user);
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserDTO>> Register([FromBody] User val)
        {
            UserDTO user = await _service.AddUser(val);
            if (user == null)
            {
                return BadRequest("Password too weak");
            }
            return CreatedAtAction(nameof(Get), new { user.Id }, user);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User value)
        {
            bool success = await _service.UpdateUser(value, id);
            if (!success)
            {
                return BadRequest("Password too weak");
            }
            return Ok(value);
        }
    }
}
