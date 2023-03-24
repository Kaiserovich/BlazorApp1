using BlazorApp1;
using BlazorApp1.Contracts;
using BlazorApp1.Entities;
using BlazorApp1.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Repository
{
    //Сделать все async
    public class OrderRepository  : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext dbContext) : base(dbContext){}
        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await FindAll().ToListAsync();
        }
        public async Task<List<Order>> GetOrdersByClientIdAsync(int clientId)
        {
            return await FindByCondition(a => a.ClientId.Equals(clientId)).ToListAsync();
        }
        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await FindByCondition(a => a.Id.Equals(id)).FirstOrDefaultAsync();
        }
        public void CreateOrder(Order order)
        {
            Create(order);
        }
        public void UpadateOrder(Order order)
        {
            Update(order);
        }
        public void DeleteOrder(Order order)
        {
            Delete(order);
        }
    }
}
