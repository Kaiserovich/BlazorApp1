using BlazorOrders.Contracts;
using BlazorOrders.Entities.Enumerations;
using BlazorOrders.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorOrders.Services
{
    public class ClientService : IClientService
    {
        private readonly IRepositoryWrapper repoWrapper;
        public ClientService(IRepositoryWrapper repoWrapper) => this.repoWrapper = repoWrapper;
        public async Task<List<Client>> GetAllClientsAsync() => await repoWrapper.Client.FindAll().ToListAsync();
        public async Task<List<Client>> GetClientsByStatusAsync(ClientStatus status) => await repoWrapper.Client.FindAll().Where(x => x.Status == status).ToListAsync();
        public async Task<Client> GetClientByIdAsync(int id) => await repoWrapper.Client.FindByCondition(a => a.Id.Equals(id)).FirstOrDefaultAsync();
        public async Task CreateClientAsync(Client client)
        {
            client.DataCreate = DateTime.Now;
            client.Status = 0;

            repoWrapper.Client.CreateClient(client);
            await repoWrapper.SaveAsync();
        }
        public string UpadateClient(Client client)
        {
            if (client.Status == ClientStatus.Inactive && repoWrapper.Order.GetOrdersByClientId(client.Id).Where(order => order.Status == OrderStatus.New).Count() != 0)
                return $"The client has orders in a new status. So the client's status be changed";
            else
            {
                repoWrapper.Client.Update(client);
                repoWrapper.SaveAsync();

                return string.Empty;
            }
        }
        public void DeleteClient(Client client)
        {
            repoWrapper.Client.Delete(client);
            repoWrapper.SaveAsync();
        }
    }
}
