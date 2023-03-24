using BlazorApp1.Entities.Models;

namespace BlazorApp1.Contracts
{
    public interface IClientRepository : IRepositoryBase<Client>
    {
        List<Client> GetAllClients();
        Client GetClientById(int id);
        void CreateClient(Client client);
        void UpadateClient(Client client);
        void DeleteClient(Client client);
    }
}
