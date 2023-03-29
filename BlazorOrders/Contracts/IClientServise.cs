using BlazorOrders.Entities.Models;

namespace BlazorOrders.Contracts
{
    public interface IClientService
    {
        Task<List<Client>> GetAllClientsAsync();
        Task<Client> GetClientByIdAsync(int id);
        Task<string> CreateClientAsync(Client client);
        string UpadateClient(Client client);
        void DeleteClient(Client client);
    }
}
