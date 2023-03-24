using BlazorApp1;
using BlazorApp1.Contracts;
using BlazorApp1.Entities;
using BlazorApp1.Entities.Models;

namespace BlazorApp1.Repository
{
    //Сделать все async
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(AppDbContext dbContext) : base(dbContext) { }

        public List<Client> GetAllClients()
        {
            return FindAll().ToList();
        }
        public Client GetClientById(int id)
        {
            return FindByCondition(a => a.Id.Equals(id)).First();
        }
        public void CreateClient(Client client)
        {
            Create(client);
        }
        public void UpadateClient(Client client)
        {
            Update(client);
        }
        public void DeleteClient(Client client)
        {
            Delete(client);
        }

    }
}
