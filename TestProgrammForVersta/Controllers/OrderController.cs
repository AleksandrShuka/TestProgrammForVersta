using Microsoft.AspNetCore.Mvc;
using TestProgrammForVersta.Data;
using TestProgrammForVersta.Repo;

namespace TestProgrammForVersta.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrdersContext db = new();

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return db.Orders.ToArray();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Order order)
        {
            if (null == order)
            {
                return BadRequest();
            }

            db.Orders.Add(order);
            db.SaveChanges();
            return Created(new Uri($"{Request.Path}/{order.Id}", UriKind.Relative), order.Id);
        }
    }
}