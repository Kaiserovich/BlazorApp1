using BlazorApp1;
using BlazorApp1.Entities;
using BlazorApp1.Entities.Models;

namespace BlazorApp1.Repository
{
    //Сделать все async
    public class SqlRepository : IRepository
    {
        private readonly AppDbContext _db;

        public SqlRepository(AppDbContext dbContext)
        {
            _db = dbContext;
        }
        public bool CreateClient(Client client)
        {
            if (client is null)
                return false;

            _db.Add(client);
            _db.SaveChanges();
            return true;
        }

        public bool CreateOrder(Order order)
        {
            if (order is null)
                return false;

            _db.Add(order);
            _db.SaveChanges();
            return true;
        }

        public bool DeleteClient(Client client)
        {
            if (client is null)
                return false;

            _db.Remove(client);
            _db.SaveChanges();
            return true;
        }

        public bool DeleteOrder(Order order)
        {
            if (order is null)
                return false;

            _db.Remove(order);
            _db.SaveChanges();
            return true;
        }

        public bool EditClient(Client client)
        {
            if (client is null)
                return false;

            _db.Clients.Update(client);
            _db.SaveChanges();
            return true;
        }

        public bool EditOrder(Order order)
        {
            if (order is null)
                return false;

            _db.Orders.Update(order);
            _db.SaveChanges();
            return true;
        }

        public List<Client> GetAllClients()
        {
            var result = _db.Clients.ToList();
            return result;
        }


        public List<Order> GetAllOrders()
        {
            var result = _db.Orders.ToList();
            return result;
        }

        public Client GetClientById(int id)
        {
            var result = _db.Clients.FirstOrDefault(x => x.Id == id);
            return result;
        }

        public Order GetOrderById(int id)
        {
            var result = _db.Orders.FirstOrDefault(x => x.Id == id);
            return result;
        }

        public List<Order> GetOrdersByClientId(int clientId)
        {
            var result = _db.Orders.Where(order => order.ClientId == clientId).ToList();
            return result;
        }

        /* .Join(_db.Clients,
        order => order.ClientId,
        client => client.Id, (order, client) => new
        {
            Id = order.Id,
            Decription = order.Decription,
            Date = order.Date,
            Price = order.Price,
            Status = order.Status,
            CurrencyId = order.CurrencyId

        }).ToList();*/

    }
}
