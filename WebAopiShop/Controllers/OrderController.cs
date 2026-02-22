using DTOs;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> Get(int id)
        {
            OrderDTO order = await _service.GetOrderById(id);
            if (order == null)
            {
                return NoContent();
            }
            return Ok(order);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> Get(int id)
        {
            OrderDTO order = await service.GetOrderById(id);
            if (order == null)
            {
                return NoContent();
            }
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<OrderDTO>> AddOrder([FromBody] Order order)
        {
            OrderDTO order2 = await service.AddOrder(order);
            return CreatedAtAction(nameof(Get), new {order2.OrderId}, order2);
        }
    }
}
