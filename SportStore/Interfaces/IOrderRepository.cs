using SportStore.Models;

namespace SportStore.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Orders { get; }
        Order GetOrder(long id);
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order id);
    }
}
