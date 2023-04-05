using BlazorOrders.Contracts;
using BlazorOrders.Entities.Enumerations;
using BlazorOrders.Entities.Models;
using BlazorOrders.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorOrders.Infrastructure
{
    public class OrderService : IOrderService
    {
        private readonly IRepositoryWrapper repoWrapper;
        public OrderService(IRepositoryWrapper repoWrapper) => this.repoWrapper = repoWrapper;
        public async Task<List<Order>> GetAllOrdersAsync() => await repoWrapper.Order.FindAll().ToListAsync();
        public List<Order> GetOrdersByClientId(int clientId) => repoWrapper.Order.FindByCondition(a => a.ClientId.Equals(clientId)).ToList();
        public async Task<Order> GetOrderByIdAsync(int id) => await repoWrapper.Order.FindByCondition(a => a.Id.Equals(id)).FirstOrDefaultAsync();
        public async Task<Order> GetLastOrdersAsync() => await repoWrapper.Order.FindAll().LastOrDefaultAsync();

        public async Task CreateOrderAsync(Order order)
        {
            order.Status = 0;
            order.Date = DateTime.Now;

            repoWrapper.Order.Create(order);
            await repoWrapper.SaveAsync();
        }
        public void UpadateOrder(Order order)
        {
            repoWrapper.Order.Update(order);
            repoWrapper.SaveAsync();
        }
        public void DeleteOrder(Order order)
        {
            repoWrapper.Order.Delete(order);
            repoWrapper.SaveAsync();
        }
    }
}
