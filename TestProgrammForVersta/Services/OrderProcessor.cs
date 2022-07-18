using TestProgrammForVersta.Data;
using TestProgrammForVersta.Repo;

namespace TestProgrammForVersta.Services
{
    public class OrderProcessor
    {
        private readonly Repository _repo = new();

        public OrderProcessor()
        {
        }

        public IEnumerable<Order> GetOrders()
        {
            return _repo.GetAll();
        }

        public int AddOrder(Order order)
        {
            _repo.Insert(order);
            return order.Id;
        }
    }
}

