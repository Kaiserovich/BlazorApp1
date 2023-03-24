using BlazorApp1.Entities.Models;

namespace BlazorApp1.Contracts
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        List<Order> GetAllOrders();
        Order GetOrderById(int id);
        void CreateOrder(Order order);
        void UpadateOrder(Order order);
        void DeleteOrder(Order order);
        List<Order> GetOrdersByClientId(int clientId);
    }
}
