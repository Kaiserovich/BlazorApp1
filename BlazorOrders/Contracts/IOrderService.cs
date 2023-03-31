using BlazorOrders.Entities.Models;

namespace BlazorOrders.Contracts
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllOrdersAsync();
        List<Order> GetOrdersByClientId(int clientId);
        Task<Order> GetLastOrdersAsync();
        Task<Order> GetOrderByIdAsync(int id);
        Task CreateOrderAsync(Order order);
        void UpadateOrder(Order order);
        void DeleteOrder(Order order);
    }
}
