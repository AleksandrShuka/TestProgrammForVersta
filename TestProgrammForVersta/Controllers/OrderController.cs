using Microsoft.AspNetCore.Mvc;

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
            return db.Orders.ToList();
        }

        [HttpPost("create")]
        public object Create([FromBody] Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return order;
        }
    }
}