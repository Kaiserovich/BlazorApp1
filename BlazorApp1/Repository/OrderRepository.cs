using BlazorApp1;
using BlazorApp1.Contracts;
using BlazorApp1.Entities;
using BlazorApp1.Entities.Models;

namespace BlazorApp1.Repository
{
    //Сделать все async
    public class OrderRepository  : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext dbContext) : base(dbContext){}
        public List<Order> GetAllOrders()
        {
            return FindAll().ToList();
        }
        public Order GetOrderById(int id)
        {
            return FindByCondition(a => a.Id.Equals(id)).First();
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

        public List<Order> GetOrdersByClientId(int clientId)
        {
            return FindByCondition(a => a.ClientId.Equals(clientId)).ToList();
        }
    }
}
