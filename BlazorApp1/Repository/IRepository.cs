using BlazorApp1.Entities.Models;

namespace BlazorApp1.Repository
{
    public interface IRepository
    {
        List<Client> GetAllClients();
        Client GetClientById(int id);
        bool CreateClient(Client client);
        bool EditClient(Client client);
        bool DeleteClient(Client client);



        List<Order> GetAllOrders();
        Order GetOrderById(int id);
        bool CreateOrder(Order order);
        bool EditOrder(Order order);
        bool DeleteOrder(Order order);
        List<Order> GetOrdersByClientId(int clientId);

    }
}
