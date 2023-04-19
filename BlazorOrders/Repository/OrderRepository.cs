using BlazorOrders;
using BlazorOrders.Contracts;
using BlazorOrders.Entities;
using BlazorOrders.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorOrders.Repository
{
    //Сделать все async
    public class OrderRepository  : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext dbContext) : base(dbContext){}
        public async Task<List<Order>> GetAllOrdersAsync() => 
            await FindAll()
            .ToListAsync();
        public List<Order> GetOrdersByClientId(int clientId) => 
            FindByCondition(a => a.ClientId.Equals(clientId))
            .ToList();
        public async Task<Order> GetOrderByIdAsync(int id) => 
            await FindByCondition(a => a.Id.Equals(id))
            .FirstOrDefaultAsync();
        public void CreateOrder(Order order) => Create(order);
        public void UpadateOrder(Order order) => Update(order);
        public void DeleteOrder(Order order) => Delete(order);
    }
}
