using BlazorApp1;
using BlazorApp1.Contracts;
using BlazorApp1.Entities;
using BlazorApp1.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Repository
{
    //Сделать все async
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(AppDbContext dbContext) : base(dbContext) { }

        public async Task<List<Client>> GetAllClientsAsync()
        {
            return await FindAll().ToListAsync();
        }
        public async Task<Client> GetClientByIdAsync(int id)
        {
            return await FindByCondition(a => a.Id.Equals(id)).FirstOrDefaultAsync();
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
