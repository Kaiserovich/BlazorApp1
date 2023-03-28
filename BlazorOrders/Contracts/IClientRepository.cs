using BlazorOrders.Entities.Models;

namespace BlazorOrders.Contracts
{
    public interface IClientRepository : IRepositoryBase<Client>
    {
        Task<List<Client>> GetAllClientsAsync();
        Task<Client> GetClientByIdAsync(int id);
        void CreateClient(Client client);
        void UpadateClient(Client client);
        void DeleteClient(Client client);
    }
}
