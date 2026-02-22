using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebAopiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        private readonly IPasswordService _service;

        public PasswordController(IPasswordService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult<CheckPassword> CheckPass([FromBody] string pass)
        {
            CheckPassword password = _service.Check(pass);
            if (password == null)
            {
                return NoContent();
            }
            return Ok(password);
        }
    }
}
