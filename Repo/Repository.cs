using Microsoft.EntityFrameworkCore;
using TestProgrammForVersta.Data;

namespace TestProgrammForVersta.Repo
{
    public class Repository : IRepository
    {
        private readonly OrdersContext _context;
        private readonly DbSet<Order> _entities;

        public Repository()
        {
            _context = new();
            _entities = _context.Orders;
        }

        public Repository(OrdersContext context)
        {
            _context = context;
            _entities = _context.Orders;
        }

        public void Delete(Order entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public Order? Get(long id)
        {
            return _entities.SingleOrDefault(s => s.Id == id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public void Insert(Order entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Add(entity);
            _context.SaveChanges();
        }

        public void Remove(Order entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Remove(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
