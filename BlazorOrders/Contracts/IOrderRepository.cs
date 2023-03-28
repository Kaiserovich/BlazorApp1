using BlazorOrders.Entities.Models;

namespace BlazorOrders.Contracts
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        Task<List<Order>> GetAllOrdersAsync();
        List<Order> GetOrdersByClientId(int clientId);
        Task<Order> GetOrderByIdAsync(int id);
        void CreateOrder(Order order);
        void UpadateOrder(Order order);
        void DeleteOrder(Order order);
    }
}
