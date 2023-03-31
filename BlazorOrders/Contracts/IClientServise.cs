using BlazorOrders.Entities.Enumerations;
using BlazorOrders.Entities.Models;

namespace BlazorOrders.Contracts
{
    public interface IClientService
    {
        Task<List<Client>> GetAllClientsAsync();
        Task<List<Client>> GetClientsByStatusAsync(ClientStatus status);
        Task<Client> GetClientByIdAsync(int id);
        Task CreateClientAsync(Client client);
        string UpadateClient(Client client);
        void DeleteClient(Client client);
    }
}
