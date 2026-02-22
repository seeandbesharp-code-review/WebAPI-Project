using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebAopiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> Get()
        {
            List<Category> categories = await _service.GetCategories();
            if (categories == null)
            {
                return NoContent();
            }
            return Ok(categories);
        }
    }
}
