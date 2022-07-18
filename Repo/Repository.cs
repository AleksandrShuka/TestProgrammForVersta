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

            try
            {
                _entities.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                // ...
            }
        }

        public Order? Get(long id)
        {
            Order? result = null;
            try
            {
                result = _entities.SingleOrDefault(s => s.Id == id);
            }
            catch (Exception e)
            {
                // ...
            }

            return result;
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

            try
            {
                _entities.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                // ...
            }
        }

        public void Remove(Order entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            try
            {
                _entities.Remove(entity);
            }
            catch (Exception e)
            {

            }
        }

        public async void SaveChanges()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                // ...
            }
        }
    }
}
