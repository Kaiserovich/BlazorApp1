using BlazorApp1;
using BlazorApp1.Entities;
using BlazorApp1.Entities.Models;

namespace BlazorApp1.Repository
{
    //Сделать все async
    public class SqlRepository : IRepository
    {
        private readonly AppDbContext _dbContext;

        public SqlRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool CreateClient(Client client)
        {
            if (client is null)
                return false;

            _dbContext.Add(client);
            _dbContext.SaveChanges();
            return true;
        }

        public bool CreateOrder(Order order)
        {
            if (order is null)
                return false;

            _dbContext.Add(order);
            _dbContext.SaveChanges();
            return true;
        }

        public bool DeleteClient(Client client)
        {
            throw new NotImplementedException();
        }

        public bool DeleteOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public bool EditClient(Client client)
        {
            if (client is null)
                return false;

            _dbContext.Clients.Update(client);
            _dbContext.SaveChanges();
            return true;
        }

        public bool EditOrder(Order order)
        {
            if (order is null)
                return false;

            _dbContext.Orders.Update(order);
            _dbContext.SaveChanges();
            return true;
        }

        public List<Client> GetAllClients()
        {
            var result = _dbContext.Clients.ToList();
            return result;
        }


        public List<Order> GetAllOrders()
        {
            var result = _dbContext.Orders.ToList();
            return result;
        }

        public Client GetClientById(int id)
        {
            var client = _dbContext.Clients.FirstOrDefault(x => x.Id == id);
            return client;
        }

        public Order GetOrderById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
