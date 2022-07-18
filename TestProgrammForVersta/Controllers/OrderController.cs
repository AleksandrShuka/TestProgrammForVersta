using Microsoft.AspNetCore.Mvc;
using TestProgrammForVersta.Data;
using TestProgrammForVersta.Services;

namespace TestProgrammForVersta.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderProcessor _orderProcessor = new();

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return _orderProcessor.GetOrders();
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] Order order)
        {
            if (null == order)
            {
                return BadRequest();
            }

            var id = _orderProcessor.AddOrder(order);
            return Created(new Uri($"{Request.Path}/{order.Id}", UriKind.Relative), id);
        }
    }
}