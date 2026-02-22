using DTOs;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebAopiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> Get(int[]? categoryId, int? minPrice, int? maxPrice, int? limit, int? page)
        {
            List<ProductDTO> products = await _service.GetProducts(categoryId, minPrice, maxPrice, limit, page);
            if (products == null)
            {
                return NoContent();
            }
            return Ok(products);
        }
    }
}
}
