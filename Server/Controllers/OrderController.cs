using Microsoft.AspNetCore.Mvc;
using TestProgrammForVersta.Data;
using TestProgrammForVersta.ServerData;
using TestProgrammForVersta.Services;

namespace TestProgrammForVersta.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderProcessor _orderProcessor = new();

        [HttpGet]
        public IEnumerable<OrderWeb> Get()
        {
            var orders = _orderProcessor.GetOrders();
            List<OrderWeb> resultOrders = new();

            foreach (var order in orders)
            {
                resultOrders.Add(new OrderWeb(order.Id, order.SenderCity, order.SenderAddress, order.RecieverCity,
                    order.RecieverAddress, order.Weight, order.Date.Date.ToString("d")));
            }
            return resultOrders;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] OrderWeb order)
        {
            if (null == order)
            {
                return BadRequest();
            }
            var resultOrder = new Order(order.Id, order.SenderCity, order.SenderAddress, order.RecieverCity,
                    order.RecieverAddress, order.Weight, DateTime.Parse(order.Date));

            var id = _orderProcessor.AddOrder(resultOrder);
            return Created(new Uri($"{Request.Path}/{order.Id}", UriKind.Relative), id);
        }
    }
}