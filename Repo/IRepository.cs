using TestProgrammForVersta.Data;

namespace TestProgrammForVersta.Repo
{
    public interface IRepository
    {
        IEnumerable<Order> GetAll();
        Order? Get(long id);
        void Insert(Order entity);
        void Delete(Order entity);
        void Remove(Order entity);
        void SaveChanges();
    }
}
