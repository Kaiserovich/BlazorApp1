using BlazorApp1.Entities.Models;

namespace BlazorApp1.Contracts
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
